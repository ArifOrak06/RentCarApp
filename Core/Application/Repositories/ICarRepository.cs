using Domain.Entities.Concrete;
using Domain.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Application.Repositories
{
	public interface ICarRepository : IRepositoryBase<Car>
	{
		Task<PagedList<Car>> GetAllCarsAsync(bool trackChanges, CarRequestParameters carRequestParameters, Expression<Func<Car, bool>> predicate, params Expression<Func<Car, object>>[] includeProperties);
	}
}
