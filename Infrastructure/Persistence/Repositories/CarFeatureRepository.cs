using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class CarFeatureRepository : RepositoryBase<CarFeature>, ICarFeatureRepository
	{
		public CarFeatureRepository(AppDbContext context) : base(context)
		{
		}
	}
}
