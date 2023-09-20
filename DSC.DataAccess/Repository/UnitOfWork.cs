using DSC.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using RoutelaAPI.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

		public IFamilyRepository Family { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IArticleRepository Article { get; private set; }
        public IApplyRepository Apply { get; private set; }
        public ISocialProfilesRepository SocialProfiles { get; private set; }
        public IServiceRepository Service { get; private set; }
        public IFounderRepository Founder { get; private set; }
        public IVolunteerRepository Volunteer { get; private set; }

		public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Volunteer = new VolunteerRepository(_context);
            Founder = new FounderRepository(_context);
            Service = new ServiceRepository(_context);
            SocialProfiles = new SocialProfilesRepository(_context);
            Apply = new ApplyRepository(_context);
            Article = new ArticleRepository(_context);
            Category = new CategoryRepository(_context);
            Family = new FamilyRepository(_context);


        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}