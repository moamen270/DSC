namespace DSC.Extentions
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.Configure<MailSetting>(configuration.GetSection("MailSettingsGmail"));
            return services;
        }
    }
}