using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class PricingRepository : RepositoryBase<Pricing>, IPricingRepository
	{
		public PricingRepository(AppDbContext context) : base(context)
		{
		}
	}
}
