namespace DSC.Models
{
	public class SocialProfiles
	{
        public int Id { get; set; }
        public string Type { get; set; }
        public string IconUrl { get; set; }
        public string ProfileUrl { get; set; }
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}
