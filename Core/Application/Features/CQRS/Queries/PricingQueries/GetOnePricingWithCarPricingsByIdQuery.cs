using Application.Features.CQRS.Results.PricingResults;
using MediatR;

namespace Application.Features.CQRS.Queries.PricingQueries
{
	public class GetOnePricingWithCarPricingsByIdQuery : IRequest<GetOnePricingWithCarPricingsByIdQueryResult>
	{
        public int Id { get; set; }
        public GetOnePricingWithCarPricingsByIdQuery(int id)
        {
            Id  = id;
        }
    }
}
