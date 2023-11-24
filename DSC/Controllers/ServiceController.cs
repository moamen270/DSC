using DSC.Models;
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
        public async Task<IActionResult> HomeService()
        {
            var services = await _unitOfWork.Service.GetAllAsync();
            foreach (var service in services)
            {
                int halfLength = service.Description.Length / 2;
                service.Description = service.Description.Substring(0, halfLength);
            }
            return View(new ServiceDto { Services = services });
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var services = await _unitOfWork.Service.GetAllAsync();
            return View(new ServiceDto { Services = services });
        }
        [HttpGet]
        public async Task<IActionResult> UserDetails(int id)
        {
            var service = await _unitOfWork.Service.FirstOrDefaultAsync(a => a.Id == id);
            var services = await _unitOfWork.Service.GetAllAsync();

            var se = new ServiceDto
            {
                Services = services,
                Name = service.Name,
                Id = id,
                Description = service.Description,
                ImgUrl = service.ImgUrl,
            };

            if (service == null)
                return NotFound();
            return View(se);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int ServiceId)
        {
            var service = await _unitOfWork.Service.FirstOrDefaultAsync(s => s.Id == ServiceId);
            if (service == null)
                return NotFound();

            var applies = await _unitOfWork.Apply.GetAllAsync(filter => filter.ServiceId == service.Id, includeProperties: property => property.Student.User);
            service.Applies = applies.ToList();

            return View(service);
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
