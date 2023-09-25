using DSC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
	[Route("[controller]")]
	public class CategoryController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public CategoryController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var categories =await _unitOfWork.Category.GetAllAsync();
			return View(new CategoryDto {Categories=categories});
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create(Category category)
		{
			if (ModelState.IsValid)
			{
				await _unitOfWork.Category.AddAsync(category);
				await _unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View(category);
		}

		[HttpPost("Edit")]
		public async Task<IActionResult> Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Category.Update(category);
				await _unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View(category);
		}

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(Category category)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Category.Delete(category);
				await _unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View(category);
		}
	}
}