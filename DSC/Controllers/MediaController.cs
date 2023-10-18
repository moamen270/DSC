using DSC.Models.DTOs;
using DSC.Services.IServices;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class MediaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;

        public MediaController(IUnitOfWork unitOfWork, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var medias = await _unitOfWork.Media.GetAllAsync();
            var collections = await _unitOfWork.Collection.GetAllAsync();
            return View(new MediaDto { Medias = medias, Collections = collections });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int MediaId)
        {
            var media = await _unitOfWork.Media.FirstOrDefaultAsync(media => media.Id == MediaId, property => property.Collection);

            if (media == null)
                return NotFound();

            return View(media);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Media media, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(file);
                if (result.Error != null)
                    return RedirectToAction("Index", "Error");

                media.ImageId = result.PublicId;
                media.ImageUrl = result.SecureUrl.AbsoluteUri;
                await _unitOfWork.Media.AddAsync(media);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Media media, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(media.ImageId))
                {
                    var DeleteResult = await _photoService.DeletePhotoAsync(media.ImageId);
                    if (DeleteResult.Error is not null)
                        return RedirectToAction("Index", "Error");
                }
                var result = await _photoService.AddPhotoAsync(file);
                if (result.Error != null)
                    return RedirectToAction("Index", "Error");

                media.ImageId = result.PublicId;
                media.ImageUrl = result.SecureUrl.AbsoluteUri;
                _unitOfWork.Media.Update(media);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Media media)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(media.ImageId))
                {
                    var DeleteResult = await _photoService.DeletePhotoAsync(media.ImageId);
                    if (DeleteResult.Error is not null)
                        return RedirectToAction("Index", "Error");
                }
                _unitOfWork.Media.Delete(media);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }

        /*
                [HttpPost]
                [Route("AddPhoto/{id}")]
                public async Task<IActionResult> AddPhoto(int id, IFormFile file)
                {
                    var drug = await _unitOfWork.Drug.GetFirstOrDefaultAsync(x => x.Id == id);
                    if (drug == null)
                        return NotFound();
                    if (!string.IsNullOrEmpty(drug.ImageId))
                    {
                        var DeleteResult = await _photoService.DeletePhotoAsync(drug.ImageId);
                        if (DeleteResult.Error is not null)
                            return BadRequest(DeleteResult.Error);
                    }
                    var result = await _photoService.AddPhotoAsync(file);
                    if (result.Error != null)
                        return BadRequest(result.Error);
                    drug.ImageId = result.PublicId;
                    drug.ImageURL = result.SecureUrl.AbsoluteUri;
                    _unitOfWork.Drug.Update(drug);
                    await _unitOfWork.SaveAsync();

                    return Ok(drug.ImageURL);
                }*/
    }
}