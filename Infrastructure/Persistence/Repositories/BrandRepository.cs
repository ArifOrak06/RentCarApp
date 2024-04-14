using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
	{
		public BrandRepository(AppDbContext context) : base(context)
		{
		}
	}
}
