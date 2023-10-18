using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DSC.Models.DTOs
{
    public class MediaDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaType MediaType { get; set; }
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }
        public IFormFile File { get; set; }

        public IEnumerable<Collection> Collections { get; set; }

        public IEnumerable<Media> Medias { get; set; }
    }
}