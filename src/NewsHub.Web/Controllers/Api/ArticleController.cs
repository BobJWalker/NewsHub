using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsHub.Web.Core.Models;
using NewsHub.Web.Core.Models.ViewModels;
using NewsHub.Web.DataAccess;

namespace NewsHub.Web.Controllers.Api
{
    [ApiController]
    [Route("api/articles")]
    public class ArticleController(INewsHubDataAdapter repository) : ControllerBase
    {
        [HttpGet]        
        public Task<PagedViewModel<ArticleModel>> GetAll(int currentPage = 1, int rowsPerPage = 10, string sortColumn = "Name", bool isAsc = true)
        {
            return repository.GetAllAsync<ArticleModel>(currentPage, rowsPerPage, sortColumn, isAsc);
        }
        
        [HttpGet]
        [Route("{id}")]
        public Task<ArticleModel> GetById(int id)
        {
            return repository.GetByIdAsync<ArticleModel>(id);
        }
        
        [HttpPost]
        public Task<ArticleModel> Insert(ArticleModel model)
        {
            return repository.InsertAsync(model);
        }
        
        [HttpPut]
        [Route("{id}")]
        public Task<ArticleModel> Update(ArticleModel model)
        {
            return repository.UpdateAsync(model);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public Task Delete(int id)
        {
            return repository.DeleteAsync<ArticleModel>(id);
        }
    }
}