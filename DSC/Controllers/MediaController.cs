using CloudinaryDotNet.Actions;
using DSC.Models.DTOs;
using DSC.Models.Enums;
using DSC.Services.IServices;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<IActionResult> Create(Media media)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Media.AddAsync(media);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Media media)
        {
            if (ModelState.IsValid)
            {
                var oldMedia = await _unitOfWork.Media.FirstOrDefaultAsync(m => m.Id == media.Id);
                if (!string.IsNullOrEmpty(oldMedia.PublicId))
                {
                    var DeleteResult = await _mediaService.DeleteMediaAsync(oldMedia.PublicId);
                    if (DeleteResult.Error is not null)
                        return RedirectToAction("Index", "Error");
                }
                oldMedia.CollectionId = media.CollectionId;
                oldMedia.Description = media.Description;
                oldMedia.MediaType = media.MediaType;
                oldMedia.PublicId = media.PublicId;
                oldMedia.Title = media.Title;
                oldMedia.Url = media.Url;

                _unitOfWork.Media.Update(oldMedia);
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Error");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Media request)
        {
            if (ModelState.IsValid)
            {
                var media = await _unitOfWork.Media.FirstOrDefaultAsync(m => m.Id == request.Id);
                if (!string.IsNullOrEmpty(media.PublicId))
                {
                    var DeleteResult = await _mediaService.DeleteMediaAsync(media.PublicId);
                    if (DeleteResult.Error is not null)
                        return RedirectToAction("Index", "Error");
                }
                _unitOfWork.Media.Delete(media);
                await _unitOfWork.Save();
                return RedirectToAction("Index", "Media");
            }
            return RedirectToAction("Index", "Error");
        }
    }
}