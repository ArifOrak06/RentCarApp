using Application.Features.CQRS.Results.PricingResults;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Queries.PricingQueries
{
	public class GetAllPricingsWithCarPricingsQuery : PricingRequestParameters, IRequest<(List<GetAllPricingsWithCarPricingsQueryResult> result,MetaData metaData)>
	{
        public GetAllPricingsWithCarPricingsQuery(int pageNumber,int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
