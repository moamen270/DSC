using DSC.Models;
using DSC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VolunteerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var volunteers = await _unitOfWork.Volunteer.GetAllAsync();
            return View(new VolunteerDto { Volunteers = volunteers });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var volunteer = await _unitOfWork.Volunteer.FirstOrDefaultAsync(v=>v.Id==id);
            if (volunteer == null)
                return NotFound();

            return View(volunteer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Volunteer.AddAsync(volunteer);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(volunteer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Volunteer.Update(volunteer);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(volunteer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialProfile(SocialProfile socialProfile)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.SocialProfiles.AddAsync(socialProfile);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(socialProfile);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Volunteer.Delete(volunteer);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(volunteer);
        }
    }
}