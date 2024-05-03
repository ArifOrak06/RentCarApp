using Domain.Entities.Concrete;
using Domain.Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Application.Repositories
{
	public interface IPricingRepository : IRepositoryBase<Pricing>
	{
		Task<PagedList<Pricing>> GetAllPricingAsync(bool trackChanges, PricingRequestParameters pricingRequestParameters, Expression<Func<Pricing, bool>> predicate, params Expression<Func<Pricing, object>>[] includeProperties);
	}
}
