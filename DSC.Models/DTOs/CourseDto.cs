using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DSC.Models.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }

        public IEnumerable<Topic> Topics { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}