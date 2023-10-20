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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var families = await _unitOfWork.Family.GetAllAsync();
            return View(new FamilyDto { Families = families});
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                  return RedirectToAction("Login", "Account");
            }
            var student = await _unitOfWork.Student.FirstOrDefaultAsync(s=>s.UserId==user.Id);
            return View(new FamilyDto { StudentId = student.Id });
        }
        [HttpPost]
        public async Task<IActionResult> Create(Family family)
        {
            await _unitOfWork.Family.AddAsync(family);
            await _unitOfWork.Save();
            return RedirectToAction("Index", "Family");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var family = await _unitOfWork.Family.FirstOrDefaultAsync(f=>f.Id== id);
            return View(new FamilyDto 
            {
                Id=family.Id,
                StudentId=family.StudentId,
                Name=family.Name,
                Status=family.Status,
                Relation=family.Relation,
                Job = family.Job,
                isDisability =family.isDisability,
                IsAlive=family.IsAlive,
                Income=family.Income,
                SSNImgUrl=family.SSNImgUrl,
                
            });
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Family family)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                  return RedirectToAction("Login", "Account");
            }
            var student = await _unitOfWork.Student.FirstOrDefaultAsync(s=>s.UserId==user.Id);
            family.StudentId = student.Id;
            _unitOfWork.Family.Update(family);
            await _unitOfWork.Save();
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Family family)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Family.Delete(family);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }
    }
}