using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserIndex()
        {
            return View();
        }
    }
}
