using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class ServiceController : Controller
    {


        public ServiceController()
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