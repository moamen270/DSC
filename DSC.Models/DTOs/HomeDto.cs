using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Models.DTOs
{
    public class HomeDto
    {
        public int UserCount { get; set; }
        public int ServiceCount { get; set; }
        public int CourseCount { get; set; }
        public int ArticleCount { get; set; }
        public int ApplyCount { get; set; }
        public int EnrollCount { get; set; }
        public int ContactCount { get; set; }
        public int MediaCount { get; set; }
        public List<Apply> Applies { get; set; }
        public List<Enroll> Enrolls { get; set; }
    }
}