
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

        public IActionResult Index()
        {
            return View(new StudentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
                var user = await _userManager.GetUserAsync(User);
                student.UserId = user.Id;
                await _unitOfWork.Student.AddAsync(student);
                await _unitOfWork.Save();
                return RedirectToAction("Index","Home");
        }
    }
}

