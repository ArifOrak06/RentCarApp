using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class SocialMediaRepository : RepositoryBase<SocialMedia>, ISocialMediaRepository
	{
		public SocialMediaRepository(AppDbContext context) : base(context)
		{
		}
	}
}
