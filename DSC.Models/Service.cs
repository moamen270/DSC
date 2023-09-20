namespace DSC.Models
{
	public class Service
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
		public ICollection<Apply> Applies { get; set; }
	}
}
