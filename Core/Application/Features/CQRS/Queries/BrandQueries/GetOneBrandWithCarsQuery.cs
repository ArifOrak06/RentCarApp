using Application.Features.CQRS.Results.BrandResults;
using MediatR;

namespace Application.Features.CQRS.Queries.BrandQueries
{
	public class GetOneBrandWithCarsQuery : IRequest<GetOneBrandWithCarsQueryResult>
	{
        public int Id { get; set; }
        public GetOneBrandWithCarsQuery(int id)
        {
            Id = id;
        }
    }
}
