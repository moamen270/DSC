using DSC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var services = await _unitOfWork.Service.GetAllAsync();
            return View(new ServiceDto { Services = services });
        }

        [HttpGet]
        public async Task<IActionResult> HomeService()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Service.AddAsync(service);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Service.Update(service);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Service service)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Service.Delete(service);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(service);
        }
    }
}