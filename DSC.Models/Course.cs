using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public ICollection<CourseInfo> CourseInfo { get; set; }
    }
}