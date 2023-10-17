using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
