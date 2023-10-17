using DSC.Models.DTOs;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = await _unitOfWork.Course.GetAllAsync(includeProperties: property => property.Topic);
            var topics = await _unitOfWork.Topic.GetAllAsync();
            return View(new CourseDto { Courses = courses, Topics = topics });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int CourseId)
        {
            var course = await _unitOfWork.Course.FirstOrDefaultAsync(course => course.Id == CourseId, property => property.Topic);

            if (course == null)
                return NotFound();
            var courseInfos = await _unitOfWork.CourseInfo.GetAllAsync(info => info.CourseId == course.Id);

            return View(new CourseInfoDto
            {
                Course = course,
                CourseInfos = courseInfos,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Course.AddAsync(course);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Course.Update(course);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Course course)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Course.Delete(course);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> AddInfo(CourseInfo courseInfo)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.CourseInfo.AddAsync(courseInfo);
                await _unitOfWork.Save();
                return RedirectToAction("Details", "Course", new { courseInfo.CourseId });
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> EditInfo(CourseInfo courseInfo)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CourseInfo.Update(courseInfo);
                await _unitOfWork.Save();
                return RedirectToAction("Details", "Course", new { courseInfo.CourseId });
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInfo(CourseInfo courseInfo)
        {
            if (ModelState.IsValid)
            {
                var id = courseInfo.CourseId;
                _unitOfWork.CourseInfo.Delete(courseInfo);
                await _unitOfWork.Save();
                return RedirectToAction("Details", "Course", new { CourseId = id });
            }
            return RedirectToAction("Index", "Error");
        }
    }
}