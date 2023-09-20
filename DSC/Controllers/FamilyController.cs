using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class FamilyController : Controller
    {


        public FamilyController()
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