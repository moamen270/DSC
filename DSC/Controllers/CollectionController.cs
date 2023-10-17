using DSC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    [Route("[controller]")]
    public class CollectionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollectionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collections = await _unitOfWork.Collection.GetAllAsync();
            return View(new CollectionDto { Collections = collections });
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Collection collection)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Collection.AddAsync(collection);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(Collection collection)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Collection.Update(collection);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(Collection collection)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Collection.Delete(collection);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }
    }
}