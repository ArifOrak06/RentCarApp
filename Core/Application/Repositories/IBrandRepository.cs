using Domain.Entities.Concrete;
using Domain.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Application.Repositories
{
	public interface IBrandRepository : IRepositoryBase<Brand>
	{
		Task<PagedList<Brand>> GetAllBrandsAsync(bool trackChanges, BrandRequestParameters brandRequestParameters, Expression<Func<Brand, bool>> predicate, params Expression<Func<Brand, object>>[] includeProperties);
		
	}
}
