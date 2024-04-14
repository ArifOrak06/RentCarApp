using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class ProvidedServiceRepository : RepositoryBase<ProvidedService>, IProvidedServiceRepository
	{
		public ProvidedServiceRepository(AppDbContext context) : base(context)
		{
		}
	}
}
