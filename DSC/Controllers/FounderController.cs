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


        public IActionResult Index()
        {
            return View();
        }

		[HttpGet]
		public IActionResult Create()
		{
			return View();
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
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var founder = await _unitOfWork.Founder.FirstOrDefaultAsync(c => c.Id == id);
			if (founder == null)
			{
				return NotFound();
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
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var founder = await _unitOfWork.Founder.FirstOrDefaultAsync(c => c.Id == id);
			if (founder == null)
			{
				return NotFound();
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