using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Services.IServices
{
    public interface IEmailService
    {
        Task SendAsync(string mailTo, string subject, string body, IList<IFormFile> attachments = null);
    }
}