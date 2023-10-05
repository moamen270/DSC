namespace DSC.Models.DTOs
{
    public class VolunteerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public ICollection<SocialProfile> SocialProfiles { get; set; }

        public IEnumerable<Volunteer> Volunteers { get; set; }

    }
}
