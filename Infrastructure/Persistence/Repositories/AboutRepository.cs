using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class AboutRepository : RepositoryBase<About>,IAboutRepository
	{
        public AboutRepository(AppDbContext context) : base(context)
        {
               
        }

        
    }
}
