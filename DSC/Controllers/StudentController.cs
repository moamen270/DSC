
using DSC.Models.DTOs;


namespace DSC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        public StudentController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);


            var existingStudent = await _unitOfWork.Student.FirstOrDefaultAsync(ex => ex.UserId == user.Id);

            if (existingStudent != null)
            {
                return RedirectToAction(nameof(AlreadyRegistered));
            }
            else
            {
                return View( new StudentDto());
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            var user = await _userManager.GetUserAsync(User);


            var existingStudent = await _unitOfWork.Student.FirstOrDefaultAsync(ex => ex.UserId == user.Id);

            if (existingStudent != null)
            {
                return RedirectToAction("AlreadyRegistered");
            }
            else
            {
                student.UserId = user.Id;
                await _unitOfWork.Student.AddAsync(student);
                await _unitOfWork.Save();
                return RedirectToAction("Index", "Home");
            }

        }
        public IActionResult AlreadyRegistered()
        {
            return View();
        }

    }
}

