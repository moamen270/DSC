using DSC.DataAccess.Repository;
using DSC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> UserIndex()
        {
            var services = await _unitOfWork.Service.GetAllAsync();
            foreach (var service in services)
            {
                int halfLength = service.Description.Length / 2;
                service.Description = service.Description.Substring(0, halfLength);
            }
            return View(new ServiceDto { Services = services });
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}