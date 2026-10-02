using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsHub.Web.Core.Models;
using NewsHub.Web.DataAccess;

namespace NewsHub.Web.Controllers
{
    public class FeedLoadController(INewsHubDataAdapter newsHubDataAdapter) : Controller
    {
        public async Task<IActionResult> Index(int currentPage = 1, int rowsPerPage = 10, string sortColumn = "Name", bool isAsc = true)
        {
            var pagedSyncView = await newsHubDataAdapter.GetAllAsync<FeedLoadModel>(currentPage, rowsPerPage, sortColumn, isAsc);

            return View(pagedSyncView);
        }
    }
}
