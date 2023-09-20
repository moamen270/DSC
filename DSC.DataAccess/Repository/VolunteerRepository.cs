namespace RoutelaAPI.DataAccess.Repository
{
    public class VolunteerRepository : Repository<Volunteer>, IVolunteerRepository
	{
        private readonly ApplicationDbContext _context;

        public VolunteerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
