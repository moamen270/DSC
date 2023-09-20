using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class VolunteerController : Controller
    {
        public VolunteerController()
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