using Application.Repositories;
using Domain.Entities.Concrete;
using Domain.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
	public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
	{
		public BrandRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<PagedList<Brand>> GetAllBrandsAsync(bool trackChanges, BrandRequestParameters brandRequestParameters, Expression<Func<Brand, bool>> predicate, params Expression<Func<Brand, object>>[] includeProperties)
		{
			var entities = await GetByFilter(trackChanges,predicate,includeProperties).ToListAsync();
			if (entities.Any())
				throw new Exception("Sistemde kayıtlı olan herhangi bir marka bulunmamaktadır.");
			return PagedList<Brand>.ToPagedList(entities, brandRequestParameters.PageNumber, brandRequestParameters.PageSize);
		}
	}
}
