using System;
using NewsHub.Web.Core.Constants;
using NewsHub.Web.Core.Models;

namespace NewsHub.Web.BusinessLogic.Factories
{
    public interface IFeedLoadLogFactory
    {
        FeedLoadLogModel MakeInformationLog(string message, int syncId);
        FeedLoadLogModel MakeErrorLog(string message, int syncId);
        FeedLoadLogModel MakeWarningLog(string message, int syncId);
        FeedLoadLogModel Make(string message, int syncId, string logType);
    }

    public class FeedLoadLogFactory : IFeedLoadLogFactory
    {
        public FeedLoadLogModel MakeInformationLog(string message, int syncId)
        {
            return Make(message, syncId, LogType.Normal);
        }

        public FeedLoadLogModel MakeErrorLog(string message, int syncId)
        {
            return Make(message, syncId, LogType.Error);
        }

        public FeedLoadLogModel MakeWarningLog(string message, int syncId)
        {
            return Make(message, syncId, LogType.Warning);
        }

        public FeedLoadLogModel Make(string message, int feedLoadId, string logType)
        {
            return new FeedLoadLogModel
            {
                FeedLoadId = feedLoadId,
                Created = DateTime.UtcNow,
                Message = message,
                Type = logType
            };
        }
    }
}
