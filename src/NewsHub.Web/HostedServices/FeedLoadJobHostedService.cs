using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenFeature;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewsHub.Web.BusinessLogic.Factories;
using NewsHub.Web.BusinessLogic.Syncers;
using NewsHub.Web.Core.Constants;
using NewsHub.Web.Core.Models;
using NewsHub.Web.Core.Models.ViewModels;
using NewsHub.Web.DataAccess;

namespace NewsHub.Web.HostedServices
{
    public class FeedLoadJobHostedService(ILogger<FeedLoadJobHostedService> logger,
            INewsHubDataAdapter tridentDataAdapter,
            IFeedLoadJobCompositeModelFactory syncJobCompositeModelFactory,
            IInstanceSyncer instanceSyncer,
            IFeatureClient featureClient) 
        : BackgroundService, IDisposable
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var isEnabled = await featureClient.GetBooleanValueAsync("BackgroundSyncJob", false);

            if (isEnabled == false)
            {
                logger.LogInformation("Background sync job is disabled.");
                return;
            }

            using (var timer = new PeriodicTimer(TimeSpan.FromSeconds(15)))
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    while(await timer.WaitForNextTickAsync())
                    {
                        await RunJobAsync(stoppingToken);
                    }
                }
            }
        }

        private async Task RunJobAsync(CancellationToken stoppingToken)
        {
            var recordsToProcess = await GetNextRecordsToProcessAsync();

            logger.LogInformation($"Found {recordsToProcess.Items.Count} record(s) to process.");

            foreach (var syncJob in recordsToProcess.Items)
            {
                var syncJobCompositeModel = await syncJobCompositeModelFactory.MakeFeedLoadJobCompositeModelAsync(syncJob);

                if (stoppingToken.IsCancellationRequested)
                {
                    break;
                }

                await instanceSyncer.ProcessSyncJob(syncJobCompositeModel, stoppingToken);
            }
        }

        private Task<PagedViewModel<FeedLoadModel>> GetNextRecordsToProcessAsync()
        {
            const int rowsPerPage = 5;
            const int currentPageNumber = 1;
            var whereClause = $"Where State = '{SyncState.Queued}' and IsNull(RetryAttempts,0) < 5";

            return tridentDataAdapter.GetAllAsync<FeedLoadModel>(currentPageNumber, rowsPerPage, "Created", isAsc: true, whereClause);
        }
    }
}
