namespace RoutelaAPI.DataAccess.Repository
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
	{
        private readonly ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
