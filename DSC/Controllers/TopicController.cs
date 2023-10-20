using DSC.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
	public class TopicController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public TopicController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var topics = await _unitOfWork.Topic.GetAllAsync();
			return View(new TopicDto { Topics = topics });
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create(Topic topic)
		{
			if (ModelState.IsValid)
			{
				await _unitOfWork.Topic.AddAsync(topic);
				await _unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index", "Error");
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Topic topic)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Topic.Update(topic);
				await _unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index", "Error");
		}

		[HttpPost("Delete")]
		public async Task<IActionResult> Delete(Topic topic)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Topic.Delete(topic);
				await _unitOfWork.Save();
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index", "Error");
		}
	}
}