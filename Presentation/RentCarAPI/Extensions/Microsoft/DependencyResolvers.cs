using Application.Services.Logging;
using Application.Utilities.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using RentCarAPI.ActionFilters;
using System.Reflection;

namespace RentCarAPI.Extensions.Mictosoft
{
	public static class DependencyResolvers
	{
		public static void ConfigureSqlServer(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("SqlConnection"), opt =>
				{
					opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
				});
			});
		}
		public static void RegistrationOfMediaTR(this IServiceCollection services) => services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CarProfile).Assembly));
		public static void ConfigureNlog(this IServiceCollection services)
		{
			services.AddSingleton<ILoggerService, LoggerService>();
			
		}

		public static void ConfigureServiceOfPresentation(this IServiceCollection services)
		{
			services.AddScoped<ValidationFilterAttribute>();

		}
		public static void ConfigureAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(BannerProfile));

		}
		public static void ConfigureCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				{
					builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders("X-Pagination");
				});
			});
		}
	}
}
