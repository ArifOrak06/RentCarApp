using Application.Repositories;
using Application.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.Extensions
{
	public static class DependencyResolvers
	{
		public static void ConfigureRegistrationRepository(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryManager, RepositoryManager>();
		}
		public static void ConfigureRegistrationServiceOfPersistence(this IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, Persistence.UnitOfWork.UnitOfWork>();
		}
	}
}
