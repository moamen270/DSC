using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Models.DTOs
{
    public class StudentProfileDto
    {
        public int Id { get; set; }
        public string SSN { get; set; }
        public string SsnImageUrl { get; set; }
        public string StudentIdImageUrl { get; set; }
        public string Address { get; set; }
        public string ImgaeUrl { get; set; }
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
        public ICollection<Family> Family { get; set; }
    }
}