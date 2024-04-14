using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class BannerRepository : RepositoryBase<Banner>,IBannerRepository
	{
        public BannerRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
