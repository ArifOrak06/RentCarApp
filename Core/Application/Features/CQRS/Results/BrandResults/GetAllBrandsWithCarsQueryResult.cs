using Domain.Entities.Concrete;

namespace Application.Features.CQRS.Results.BrandResults
{
	public class GetAllBrandsWithCarsQueryResult
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car>  Cars { get; set; }
    }
}
