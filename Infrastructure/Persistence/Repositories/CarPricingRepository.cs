using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class CarPricingRepository : RepositoryBase<CarPricing>, ICarPricingRepository
	{
		public CarPricingRepository(AppDbContext context) : base(context)
		{
		}
	}
}
