using static Org.BouncyCastle.Math.EC.ECCurve;

namespace DSC.Extentions
{
	public static class IdentityServiceExtentions
	{
		public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddIdentityCore<User>(option =>
			{
				option.Password.RequireNonAlphanumeric = false;
				option.SignIn.RequireConfirmedEmail = false;
				option.SignIn.RequireConfirmedPhoneNumber = false;
			})
			 .AddRoles<Role>()
			 .AddRoleManager<RoleManager<Role>>()
			 .AddSignInManager<SignInManager<User>>()
			 .AddRoleValidator<RoleValidator<Role>>()
			 .AddEntityFrameworkStores<ApplicationDbContext>()
			 .AddDefaultTokenProviders();

			services.AddAuthentication().AddCookie("Identity.Application");

			return services;
		}
	}
}