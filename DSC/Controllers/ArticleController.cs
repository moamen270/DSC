using DSC.Models;
using DSC.Models.DTOs;
using DSC.Models.Enums;
using DSC.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DSC.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaService _mediaService;

        public ArticleController(IUnitOfWork unitOfWork, IMediaService mediaService)
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService;
        }

        public async Task<IActionResult> Index()
        {
            /*          ViewBag.Category = await _unitOfWork.Category.GetAllAsync();*/
            var categories = await _unitOfWork.Category.GetAllAsync();
            var articles = await _unitOfWork.Article.GetAllAsync();
            return View(new ArticleDto { Articles = articles, Categories = categories });
        }

        public async Task<IActionResult> UserIndex()
        {
            /*          ViewBag.Category = await _unitOfWork.Category.GetAllAsync();*/
            var categories = await _unitOfWork.Category.GetAllAsync();
            var articles = await _unitOfWork.Article.GetAllAsync();
            return View(new ArticleDto { Articles = articles, Categories = categories });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var article = await _unitOfWork.Article.FirstOrDefaultAsync(a => a.Id == id, includeProperties: c => c.Category);

            if (article == null)
                return NotFound();

            return View(article);
        }

        [HttpGet]
        public async Task<IActionResult> UserDetails(int id)
        {
            var article = await _unitOfWork.Article.FirstOrDefaultAsync(a => a.Id == id, includeProperties: c => c.Category);

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
                var Article = await _unitOfWork.Article.FirstOrDefaultAsync(m => m.Id == article.Id);
                if (!string.IsNullOrEmpty(Article.PublicId))
                {
                    var DeleteResult = await _mediaService.DeleteMediaAsync(Article.PublicId);
                    if (DeleteResult.Error is not null)
                        return RedirectToAction("Index", "Error");
                }
                Article.CategoryId = article.CategoryId;
                Article.Description = article.Description;
                Article.Tittle = article.Tittle;
                Article.PublicId = article.PublicId;
                Article.ArticleType = article.ArticleType;
                Article.ImgUrl = article.ImgUrl;
                _unitOfWork.Article.Update(Article);
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
                var Article = await _unitOfWork.Article.FirstOrDefaultAsync(m => m.Id == article.Id);
                if (!string.IsNullOrEmpty(Article.PublicId))
                {
                    var DeleteResult = await _mediaService.DeleteMediaAsync(Article.PublicId);
                    if (DeleteResult.Error is not null)
                        return RedirectToAction("Index", "Error");
                }
                _unitOfWork.Article.Delete(Article);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(article);
        }
    }
}