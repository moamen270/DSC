namespace DSC.Models
{
	public class Volunteer
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }

		public ICollection<SocialProfile> SocialProfiles { get; set; }


	}
}
