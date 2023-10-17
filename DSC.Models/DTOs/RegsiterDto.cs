using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Models.DTOs
{
    public class RegsiterDto
    {
        public string Email { get; set; }
        public string Name { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }

        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Gender[] Genders { get; set; } = Enum.GetValues<Gender>();
    }
}