using DSC.Models;
using DSC.Models.DTOs;
using DSC.Models.Enums;
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
            var volunteer = await _unitOfWork.Volunteer.FirstOrDefaultAsync(v => v.Id == id);
            if (volunteer == null)
                return NotFound();
            var socialProfiles = await _unitOfWork.SocialProfiles.GetAllAsync(p => p.VolunteerId == volunteer.Id);
            return View(new VolunteerProfileDto
            {
                Volunteer = volunteer,
                SocialProfiles = socialProfiles
            });
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

        [HttpPost]
        public async Task<IActionResult> CreateSocialProfile(SocialProfile socialProfile)
        {
            if (ModelState.IsValid)
            {
                socialProfile.Icon = socialProfile.Profile switch
                {
                    Profile.Facebook => "fa-facebook",
                    Profile.Google => "fa-google",
                    Profile.Instagram => "fa-instagram",
                    Profile.LinkedIn => "fa-linkedin",
                    Profile.Twitter => "fa-twitter",
                    Profile.Pinterest => "fa-pinterest",
                    _ => "fables-iconemail"
                };
                await _unitOfWork.SocialProfiles.AddAsync(socialProfile);
                await _unitOfWork.Save();
                return RedirectToAction("Details", "Volunteer", new { id = socialProfile.VolunteerId });
            }
            return View(socialProfile);
        }

        [HttpPost]
        public async Task<IActionResult> EditSocialProfile(SocialProfile socialProfile)
        {
            if (ModelState.IsValid)
            {
                socialProfile.Icon = socialProfile.Profile switch
                {
                    Profile.Facebook => "fa-facebook",
                    Profile.Google => "fa-google",
                    Profile.Instagram => "fa-instagram",
                    Profile.LinkedIn => "fa-linkedin",
                    Profile.Twitter => "fa-twitter",
                    Profile.Pinterest => "fa-pinterest",
                    _ => "fables-iconemail"
                };
                _unitOfWork.SocialProfiles.Update(socialProfile);
                await _unitOfWork.Save();
                return RedirectToAction("Details", "Volunteer", new { id = socialProfile.VolunteerId });
            }
            return View(socialProfile);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSocialProfile(SocialProfile socialProfile)
        {
            if (ModelState.IsValid)
            {
                int id = socialProfile.VolunteerId;
                _unitOfWork.SocialProfiles.Delete(socialProfile);
                await _unitOfWork.Save();
                return RedirectToAction("Details", "Volunteer", new { id = id });
            }
            return View(socialProfile);
        }
    }
}