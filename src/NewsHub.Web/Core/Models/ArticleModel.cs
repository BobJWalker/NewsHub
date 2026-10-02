using System.ComponentModel.DataAnnotations.Schema;

namespace NewsHub.Web.Core.Models
{
    [Table("Article")]
    public class ArticleModel : BaseModel
    {
        public string Name { get; set; }
        public string Url { get; set; }   
        public string ImageUrl { get; set; }
    }
}