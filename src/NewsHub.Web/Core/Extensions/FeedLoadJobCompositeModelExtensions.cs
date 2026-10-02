using NewsHub.Web.Core.Models.CompositeModels;

namespace NewsHub.Web.Core.Extensions
{
    public static class FeedLoadJobCompositeModelExtensions
    {
        public static string GetMessagePrefix(this FeedLoadJobCompositeModel feedLoadJobCompositeModel)
        {
            return $"Sync {feedLoadJobCompositeModel.FeedLoad.Id}: ";
        }        
    }
}