namespace DSC.DataAccess;

public class ApplicationDbContext : IdentityDbContext<User, Role, int,
    IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Role>().ToTable("Roles");
        builder.Entity<User>().ToTable("Users");
        builder.Entity<UserRole>().ToTable("UserRole");
        builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
        builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
        builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");

        builder.Entity<User>()
               .HasMany(ur => ur.UserRoles)
               .WithOne(u => u.User)
               .HasForeignKey(ur => ur.UserId)
               .IsRequired();

        builder.Entity<Role>()
            .HasMany(ur => ur.UsersRole)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
    }

    public DbSet<Apply> Applies { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseInfo> CourseInfos { get; set; }
    public DbSet<Enroll> Enrolls { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<Founder> Founders { get; set; }
    public DbSet<Media> Media { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<SocialProfile> SocialProfiles { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Volunteer> Volunteers { get; set; }
}