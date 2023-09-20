namespace RoutelaAPI.DataAccess.Repository
{
    public class FounderRepository : Repository<Founder>, IFounderRepository
    {
        private readonly ApplicationDbContext _context;

        public FounderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
