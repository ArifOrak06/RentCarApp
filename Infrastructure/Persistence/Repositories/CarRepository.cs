using Application.Repositories;
using Domain.Entities.Concrete;
using Domain.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
	public class CarRepository : RepositoryBase<Car>,ICarRepository
	{
        public CarRepository(AppDbContext context):  base(context)
        {
            
        }

		public async Task<PagedList<Car>> GetAllCarsAsync(bool trackChanges, CarRequestParameters carRequestParameters, Expression<Func<Car, bool>> predicate, params Expression<Func<Car, object>>[] includeProperties)
		{
			var entities = await GetByFilter(trackChanges, predicate,includeProperties).ToListAsync();
			if (!entities.Any())
				throw new Exception("Car varlığı sistemde bulunmamaktadır.");
			return PagedList<Car>.ToPagedList(entities, carRequestParameters.PageNumber, carRequestParameters.PageSize);
		}

		
	}
}
