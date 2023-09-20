namespace DSC.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IVolunteerRepository Volunteer { get; }
        IFounderRepository Founder { get; }
        IServiceRepository Service { get; }
        ISocialProfileRepository SocialProfiles { get; }
        IApplyRepository Apply { get; }
        IArticleRepository Article { get; }
        ICategoryRepository Category { get; }
        IFamilyRepository Family { get; }
        IUserRepository User { get; }
        ICollectionRepository Collection { get; }
        ICourseInfoRepository CourseInfo { get; }
        ICourseRepository Course { get; }
        IStudentRepository Student { get; }
        IEnrollRepository Enroll { get; }
        IMediaRepository Media { get; }
        ITopicRepository Topic { get; }

        Task<int> Save();
    }
}