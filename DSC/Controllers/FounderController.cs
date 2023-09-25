using DSC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class FounderController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;

		public FounderController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
        public async Task<IActionResult> Index()
        {
            var founders = await _unitOfWork.Founder.GetAllAsync();
            return View(new FounderDto { Founders = founders });
        }


		[HttpPost]
		public async Task<IActionResult> Create(Founder founder)
		{
			if (ModelState.IsValid)
			{
				await _unitOfWork.Founder.AddAsync(founder);
				await _unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View(founder);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Founder founder)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Founder.Update(founder);
				await _unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View(founder);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(Founder founder)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Founder.Delete(founder);
				await _unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return View(founder);
		}


	}
}