using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class LocationRepository : RepositoryBase<Location>, ILocationRepository
	{
		public LocationRepository(AppDbContext context) : base(context)
		{
		}
	}
}
