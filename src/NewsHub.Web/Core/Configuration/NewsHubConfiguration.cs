using Microsoft.Extensions.Configuration;
using System;

namespace NewsHub.Web.Core.Configuration
{
    public interface INewsHubConfiguration
    {
        string ConnectionString { get; set; }        
        string EnvironmentName { get; set; }
    }

    public class NewsHubConfiguration : INewsHubConfiguration
    {
        public string ConnectionString { get; set; }        
        public string EnvironmentName { get; set; }

        public NewsHubConfiguration()
        {
            ConnectionString = Environment.GetEnvironmentVariable("NEWSHUB_CONNECTION_STRING");            
            EnvironmentName = Environment.GetEnvironmentVariable("NEWSHUB_ENVIRONMENT");
        }
    }
}
