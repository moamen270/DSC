using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Models
{
    public class Enroll
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CourseInfoId { get; set; }
        public CourseInfo CourseInfo { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}