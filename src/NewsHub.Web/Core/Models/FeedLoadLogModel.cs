using System;
using Dapper;

namespace NewsHub.Web.Core.Models
{
    [Table("FeedLoadLog")]
    public class FeedLoadLogModel : BaseModel
    {
        public int FeedLoadId { get; set; }
        public DateTime Created { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
