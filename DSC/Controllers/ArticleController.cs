using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class ArticleController : Controller
    {
		public ArticleController()
		{
		}

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}