namespace RoutelaAPI.DataAccess.Repository
{
    public class FamilyRepository : Repository<Family>, IFamilyRepository
	{
        private readonly ApplicationDbContext _context;

        public FamilyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
