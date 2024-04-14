using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class CarRepository : RepositoryBase<Car>,ICarRepository
	{
        public CarRepository(AppDbContext context):  base(context)
        {
            
        }
    }
}
