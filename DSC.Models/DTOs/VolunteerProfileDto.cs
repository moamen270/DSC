using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Models.DTOs
{
    public class VolunteerProfileDto
    {
        public int Id { get; set; }
        public Profile Profile { get; set; }
        public string ProfileUrl { get; set; }
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
        public IEnumerable<SocialProfile> SocialProfiles { get; set; }
        public Profile[] Profiles { get; set; } = Enum.GetValues<Profile>();
    }
}