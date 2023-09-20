namespace RoutelaAPI.DataAccess.Repository
{
    public class SocialProfileRepository : Repository<SocialProfile>, ISocialProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public SocialProfileRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}