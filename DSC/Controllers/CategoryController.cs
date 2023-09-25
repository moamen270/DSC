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
			return View(categories);
		}


        [HttpGet("Create")]
        public IActionResult Create()
		{
			return View(new Category());
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
		[HttpGet("Edit/{id}")]
		public async Task<IActionResult> Edit(int id)
		{
			var category = await _unitOfWork.Category.FirstOrDefaultAsync(c => c.Id == id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}
		[HttpPost("Edit/{id}")]
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
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
		{
			var category = await _unitOfWork.Category.FirstOrDefaultAsync(c => c.Id == id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}
        [HttpPost("Delete/{id}")]
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