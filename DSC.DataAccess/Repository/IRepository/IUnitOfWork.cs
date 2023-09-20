namespace DSC.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork : IDisposable
    {
        IVolunteerRepository Volunteer { get; }
        IFounderRepository Founder { get; }
        IServiceRepository Service { get; }
        ISocialProfilesRepository SocialProfiles { get; }

        IApplyRepository Apply { get; }
        IArticleRepository Article { get; }
        ICategoryRepository Category { get; }
        IFamilyRepository Family { get; }




        Task<int> Save();
    }
}