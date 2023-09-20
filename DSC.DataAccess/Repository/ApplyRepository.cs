namespace RoutelaAPI.DataAccess.Repository
{
    public class ApplyRepository : Repository<Apply>, IApplyRepository
	{
        private readonly ApplicationDbContext _context;

        public ApplyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
