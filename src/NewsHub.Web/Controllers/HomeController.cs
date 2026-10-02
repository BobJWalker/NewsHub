using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using NewsHub.Web.BusinessLogic.Factories;
using NewsHub.Web.Core.Configuration;
using NewsHub.Web.Core.Constants;
using NewsHub.Web.Core.Models;
using NewsHub.Web.Core.Models.ViewModels;
using NewsHub.Web.DataAccess;

namespace NewsHub.Web.Controllers
{
    public class HomeController (INewsHubDataAdapter tridentDataAdapter,
            IFeedLoadModelFactory syncModelFactory)
        : Controller
    {        
        public async Task<IActionResult> Index(int currentPage = 1, int rowsPerPage = 10, string sortColumn = "Name", bool isAsc = true)
        {            
            var allInstances = await tridentDataAdapter.GetAllAsync<ArticleModel>(currentPage, rowsPerPage, sortColumn, isAsc);                  

            return View(allInstances);
        }

        public async Task<IActionResult> StartSync(string feedUrl)
        {                        
            var newSync = syncModelFactory.CreateModel(feedUrl);

            await tridentDataAdapter.InsertAsync(newSync);

            return RedirectToAction("Index", "Sync");
        }       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
