using DSC.Models.DTOs;

namespace DSC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public UserController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _unitOfWork.Student.GetAllAsync(includeProperties: s => s.User);
            return View(users);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var user = await _unitOfWork.Student.FirstOrDefaultAsync(s => s.Id == Id, includeProperties: s => s.User);
            var Family = await _unitOfWork.Family.GetAllAsync(f => f.StudentId == Id);
            user.Family = Family.ToList();
            return View(user);
        }
    }
}