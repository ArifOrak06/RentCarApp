using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class FeatureRepository : RepositoryBase<Feature>, IFeatureRepository
	{
		public FeatureRepository(AppDbContext context) : base(context)
		{
		}
	}
}
