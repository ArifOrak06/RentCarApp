using Application.Repositories;
using Domain.Entities.Concrete;
using Domain.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
	public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
	{
		public CategoryRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<PagedList<Category>> GetAllCategoriesAsync(bool trackChanges, CategoryRequestParameters categoryRequestParameters, Expression<Func<Category, bool>> predicate, params Expression<Func<Category, object>>[] includeProperties)
		{
			var entities = await GetByFilter(trackChanges,predicate,includeProperties).ToListAsync();
			if (!entities.Any())
				throw new Exception("Sistemde kayıtlı category nesnesi bulunmamaktadır.");
			return PagedList<Category>.ToPagedList(entities,categoryRequestParameters.PageNumber,categoryRequestParameters.PageSize);
		}
	}
}
