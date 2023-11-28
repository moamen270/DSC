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

        public async Task<IActionResult> Index()
        {
            var UserCount = await _unitOfWork.Student.CountAsync();
            var ServiceCount = await _unitOfWork.Service.CountAsync();
            var CourseCount = await _unitOfWork.Course.CountAsync();
            var ArticleCount = await _unitOfWork.Article.CountAsync();
            var ApplyCount = await _unitOfWork.Apply.CountAsync();
            var EnrollCount = await _unitOfWork.Enroll.CountAsync();
            var ContactCount = 0;
            var MediaCount = await _unitOfWork.Media.CountAsync();
            var Applies = await _unitOfWork.Apply.GetAllAsync(null, a => a.Student.User, s => s.Service);
            var Enrolls = await _unitOfWork.Enroll.GetAllAsync(null, a => a.Student.User, c => c.CourseInfo.Course);
            var Home = new HomeDto
            {
                UserCount = UserCount,
                ServiceCount = ServiceCount,
                CourseCount = CourseCount,
                ArticleCount = ArticleCount,
                ApplyCount = ApplyCount,
                EnrollCount = EnrollCount,
                ContactCount = ContactCount,
                MediaCount = MediaCount,
                Applies = Applies.ToList(),
                Enrolls = Enrolls.ToList()
            };
            return View(Home);
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