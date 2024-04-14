using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
	{
		public CategoryRepository(AppDbContext context) : base(context)
		{
		}
	}
}
