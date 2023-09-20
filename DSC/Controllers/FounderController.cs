using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class FounderController : Controller
    {
        public FounderController()
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