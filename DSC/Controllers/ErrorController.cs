using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
