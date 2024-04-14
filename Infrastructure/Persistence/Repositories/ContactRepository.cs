using Application.Repositories;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class ContactRepository : RepositoryBase<Contact>, IContactRepository
	{
		public ContactRepository(AppDbContext context) : base(context)
		{
		}
	}
}
