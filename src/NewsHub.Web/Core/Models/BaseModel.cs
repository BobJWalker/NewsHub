using System.ComponentModel.DataAnnotations;

namespace NewsHub.Web.Core.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
