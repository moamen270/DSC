using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DSC.Models.DTOs
{
    public class CollectionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<Collection> Collections { get; set; }
    }
}