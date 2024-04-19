using System.Linq.Expressions;

namespace Application.Repositories
{
	public interface IRepositoryBase<T>
	{
		Task<List<T>> GetAllAsync(bool trackChanges,Expression<Func<T,bool>> predicate = null,params Expression<Func<T, object>>[] includeProperties);
		IQueryable<T> GetByFilter(bool trackChanges,Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
		Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
		Task<T> CreateAsync(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
