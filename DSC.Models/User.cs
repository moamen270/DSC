using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}