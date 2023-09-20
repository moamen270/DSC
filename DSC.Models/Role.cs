namespace DSC.Models
{
	public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UsersRole { get; set; }
    }
}