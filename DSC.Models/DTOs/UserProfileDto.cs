using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Models.DTOs
{
    public class UserProfileDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string ImgUrl { get; set; }
    }
}