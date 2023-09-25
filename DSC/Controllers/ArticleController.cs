using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class ArticleController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;

		public ArticleController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		public async Task<IActionResult> Index()
		{
			var articles = await _unitOfWork.Article.GetAllAsync(includeProperties: c => c.Category);
			return View(articles);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View(new Article());
		}
		[HttpPost]
		public async Task<IActionResult> Create(Article article,int categoryId)
		{
			if (ModelState.IsValid)
			{
				article.Category = await _unitOfWork.Category.FirstOrDefaultAsync(c=>c.Id==categoryId);
				await _unitOfWork.Article.AddAsync(article);
				await _unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View(article);
		}

		[HttpGet]
		public IActionResult Edit()
		{
			return View(new Article());
		}
		[HttpPost]
		public async Task<IActionResult> Edit(Article article)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Article.Update(article);
				await _unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View(article);
		}
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var article = await _unitOfWork.Article.FirstOrDefaultAsync(c => c.Id == id);
			if (article == null)
			{
				return NotFound();
			}
			return View(article);
		}
		[HttpPost]
		public async Task<IActionResult> Delete(Article article)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Article.Delete(article);
				await _unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View(article);
		}


	}
}