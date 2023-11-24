using DSC.Models.DTOs;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class CourseInfoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseInfoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = await _unitOfWork.Course.GetAllAsync();
            var coursesInfo = await _unitOfWork.CourseInfo.GetAllAsync(includeProperties: property => property.Course);
            return View(new CourseInfoDto { Courses = courses, CoursesInfo = coursesInfo });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int CourseInfoId)
        {
            var courseInfos = await _unitOfWork.CourseInfo.FirstOrDefaultAsync(course => course.Id == CourseInfoId, property => property.Course.Topic);
            if (courseInfos == null)
                return NotFound();

            var enrolls = await _unitOfWork.Enroll.GetAllAsync(filter => filter.CourseInfoId == courseInfos.Id, includeProperties: property => property.Student.User);
            courseInfos.Students = enrolls.ToList();
            return View(courseInfos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseInfo courseInfo)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.CourseInfo.AddAsync(courseInfo);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseInfo courseInfo)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CourseInfo.Update(courseInfo);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CourseInfo courseInfo)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CourseInfo.Delete(courseInfo);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }
    }
}