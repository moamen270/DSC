namespace DSC.Models.DTOs
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }

        public IEnumerable<Service> Services { get; set; }
    }
}
