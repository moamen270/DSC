using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Models.DTOs
{
    public class StudentDto
    {
        public string SSN { get; set; }
        public string SsnImageUrl { get; set; }
        public string StudentIdImageUrl { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string DisabilityType { get; set; }
        public DateTime BithDate { get; set; }
        public string Department { get; set; }
        public CollageYear CollageYear { get; set; }
        public Language Language { get; set; }
        public StudyType StudyType { get; set; }
        public Religion Religion { get; set; }
        public Gender Gender { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Gender[] Genders { get; set; } = Enum.GetValues<Gender>();
        public CollageYear[] CollageYears { get; set; } = Enum.GetValues<CollageYear>();
        public Language[] Languages { get; set; } = Enum.GetValues<Language>();
        public Religion[] Religions { get; set; } = Enum.GetValues<Religion>();
        public StudyType[] StudyTypes { get; set; } = Enum.GetValues<StudyType>();
    }
}
