using DSC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class FamilyController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        public FamilyController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(new FamilyDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Family family)
        {
            await _unitOfWork.Family.AddAsync(family);
            await _unitOfWork.Save();
            return RedirectToAction("Index", "Home");
        }
    }
}