using Application.Repositories;
using Domain.Entities.Concrete;
using Domain.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
	public class PricingRepository : RepositoryBase<Pricing>, IPricingRepository
	{
		public PricingRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<PagedList<Pricing>> GetAllPricingAsync(bool trackChanges, PricingRequestParameters pricingRequestParameters, Expression<Func<Pricing, bool>> predicate, params Expression<Func<Pricing, object>>[] includeProperties)
		{
			var entities = await GetByFilter(trackChanges, predicate, includeProperties).ToListAsync();
			if (!entities.Any())
				throw new Exception("Sistemde Kayıtlı PRicing nesnesi bulunmamaktadır.");
			return PagedList<Pricing>.ToPagedList(entities,pricingRequestParameters.PageNumber,pricingRequestParameters.PageSize);

		}
	}
}
