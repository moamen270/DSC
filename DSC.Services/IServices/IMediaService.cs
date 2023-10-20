using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Services.IServices
{
    public interface IMediaService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<VideoUploadResult> AddVideoAsync(IFormFile file);

        Task<DeletionResult> DeleteMediaAsync(string publicId);
    }
}