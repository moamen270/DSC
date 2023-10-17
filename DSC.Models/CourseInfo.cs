using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Models
{
    public class CourseInfo
    {
        public int Id { get; set; }
        public string InstructorName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Enroll> Students { get; set; }
    }
}