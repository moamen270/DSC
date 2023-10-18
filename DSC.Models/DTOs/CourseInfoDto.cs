using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Models.DTOs
{
    public class CourseInfoDto
    {
        public int Id { get; set; }
        public string InstructorName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public IEnumerable<CourseInfo> CoursesInfo { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}