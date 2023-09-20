namespace RoutelaAPI.DataAccess.Repository
{
    public class SocialProfilesRepository : Repository<SocialProfiles>, ISocialProfilesRepository
	{
        private readonly ApplicationDbContext _context;

        public SocialProfilesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
