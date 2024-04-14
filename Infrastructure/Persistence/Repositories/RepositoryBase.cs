using Application.Repositories;
using Domain.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity, new()
	{
		protected readonly AppDbContext _context;

		public RepositoryBase(AppDbContext context)
		{
			_context = context;
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().AnyAsync();

		public async Task<T> CreateAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			return entity;
		}

		public void Delete(T entity) => _context.Set<T>().Remove(entity);

		public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges, Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = _context.Set<T>();
			if (!trackChanges && predicate is not null)
			{
				query = query.Where(predicate);
				if (includeProperties.Any())
					foreach (var property in includeProperties)
						query = query.Include(property).AsNoTracking();
				return await query.ToListAsync();
			}
			if (includeProperties.Any())
				foreach (var property in includeProperties)
					query = query.Include(property);

			return await query.ToListAsync();

		}

		public IQueryable<T> GetByFilter(bool trackChanges, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = _context.Set<T>().Where(predicate);
			if (!trackChanges)
			{
				
				if (includeProperties.Any())
					foreach (var property in includeProperties)
						query = query.Include(property).AsNoTracking();

			}
			else
			{
				if (includeProperties.Any())
					foreach (var property in includeProperties)
						query = query.Include(property);

			}
			return query;
		}

		public void Update(T entity) => _context.Set<T>().Update(entity);
	}
}
