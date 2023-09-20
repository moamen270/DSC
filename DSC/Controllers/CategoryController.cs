using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class CategoryContoller : Controller
    {
		public CategoryContoller()
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