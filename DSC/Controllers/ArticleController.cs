using DSC.Models.DTOs;
using DSC.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
  /*          ViewBag.Category = await _unitOfWork.Category.GetAllAsync();*/
            var categories = await _unitOfWork.Category.GetAllAsync();
			var articles = await _unitOfWork.Article.GetAllAsync();
			return View(new ArticleDto { Articles = articles, Categories = categories });
		}
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var article = await _unitOfWork.Article.FirstOrDefaultAsync(a => a.Id == id,includeProperties:c=>c.Category);

            if (article == null)
				return NotFound();

            return View(article);
        }



        [HttpPost]
		public async Task<IActionResult> Create(Article article)
		{
            if (ModelState.IsValid)
            {
                await _unitOfWork.Article.AddAsync(article);
                await _unitOfWork.Save();
                return RedirectToAction("Index"); 
            }
            return View(article);

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