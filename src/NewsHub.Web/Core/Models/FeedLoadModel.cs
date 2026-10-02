using System;
using Dapper;

namespace NewsHub.Web.Core.Models
{
    [Table("Sync")]
    public class FeedLoadModel : BaseModel
    {        
        public string State { get; set; }
        public string FeedUrl { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Completed { get; set; }        
        public int? RetryAttempts { get; set; }
    }
}
