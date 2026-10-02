using System.Threading.Tasks;
using NewsHub.Web.Core.Models;
using NewsHub.Web.Core.Models.CompositeModels;
using NewsHub.Web.DataAccess;

namespace NewsHub.Web.BusinessLogic.Factories
{
    public interface IFeedLoadJobCompositeModelFactory
    {
        Task<FeedLoadJobCompositeModel> MakeFeedLoadJobCompositeModelAsync(FeedLoadModel syncModel);
    }

    public class SyncJobCompositeModelFactory() : IFeedLoadJobCompositeModelFactory
    {
        public async Task<FeedLoadJobCompositeModel> MakeFeedLoadJobCompositeModelAsync(FeedLoadModel feedLoadModel)
        {            
            return new FeedLoadJobCompositeModel
            {
                FeedLoad = feedLoadModel                
            };
        }
    }
}
