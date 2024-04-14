using Application.UnitOfWork;
using Persistence.Contexts;

namespace Persistence.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;

		public UnitOfWork(AppDbContext context)
		{
			_context = context;
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

		public async Task<int> CommitAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public async ValueTask DisposeAsync()
		{
			await _context.DisposeAsync();
		}
	}
}
