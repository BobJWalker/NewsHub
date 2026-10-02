using System;
using NewsHub.Web.Core.Constants;
using NewsHub.Web.Core.Models;

namespace NewsHub.Web.BusinessLogic.Factories
{
    public interface IFeedLoadModelFactory
    {
        FeedLoadModel CreateModel(string feedUrl);
    }

    public class FeedLoadModelFactory : IFeedLoadModelFactory
    {
        public FeedLoadModel CreateModel(string feedUrl)
        {
            return new FeedLoadModel
            {
                FeedUrl = feedUrl,
                Created = DateTime.Now,                
                State = FeedLoadState.Queued                
            };
        }
    }
}
