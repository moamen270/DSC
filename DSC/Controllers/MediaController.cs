using CloudinaryDotNet.Actions;
using DSC.Models.DTOs;
using DSC.Models.Enums;
using DSC.Services.IServices;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DSC.Controllers
{
    public class MediaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaService _mediaService;

        public MediaController(IUnitOfWork unitOfWork, IMediaService photoService)
        {
            _unitOfWork = unitOfWork;
            _mediaService = photoService;
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
                RawUploadResult result =
                    media.MediaType == MediaType.Image ?
                    await _mediaService.AddPhotoAsync(file) :
                    await _mediaService.AddVideoAsync(file);

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
                    var DeleteResult = await _mediaService.DeleteMediaAsync(media.ImageId);
                    if (DeleteResult.Error is not null)
                        return RedirectToAction("Index", "Error");
                }
                RawUploadResult result =
                   media.MediaType == MediaType.Image ?
                   await _mediaService.AddPhotoAsync(file) :
                   await _mediaService.AddVideoAsync(file);

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
                media = await _unitOfWork.Media.FirstOrDefaultAsync(media => media.Id == media.Id);
                if (!string.IsNullOrEmpty(media.ImageId))
                {
                    var DeleteResult = await _mediaService.DeleteMediaAsync(media.ImageId);
                    if (DeleteResult.Error is not null)
                        return RedirectToAction("Index", "Error");
                }
                _unitOfWork.Media.Delete(media);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }
    }
}