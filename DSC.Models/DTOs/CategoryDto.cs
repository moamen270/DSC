using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DSC.Models.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
