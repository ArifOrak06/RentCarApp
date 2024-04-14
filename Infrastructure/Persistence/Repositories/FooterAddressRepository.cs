using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class FooterAddressRepository : RepositoryBase<FooterAddress>, IFooterAddressRepository
	{
		public FooterAddressRepository(AppDbContext context) : base(context)
		{
		}
	}
}
