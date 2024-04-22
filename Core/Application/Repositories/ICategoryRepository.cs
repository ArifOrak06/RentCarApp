using Domain.Entities.Concrete;
using Domain.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Application.Repositories
{
	public interface ICategoryRepository : IRepositoryBase<Category>
	{
		Task<PagedList<Category>> GetAllCategoriesAsync(bool trackChanges, CategoryRequestParameters categoryRequestParameters, Expression<Func<Category, bool>> predicate, params Expression<Func<Category, object>>[] includeProperties);
	}
}
