namespace DSC.Models
{
    public class SocialProfile
    {
        public int Id { get; set; }
        public Profile Profile { get; set; }
        public string Icon { get; set; }
        public string ProfileUrl { get; set; }
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}