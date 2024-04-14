using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class CarDescriptionRepository : RepositoryBase<CarDescription>, ICarDescriptionRepository
	{
		public CarDescriptionRepository(AppDbContext context) : base(context)
		{
		}
	}
}
