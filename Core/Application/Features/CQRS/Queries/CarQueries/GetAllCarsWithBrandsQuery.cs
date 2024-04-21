using Application.Features.CQRS.Results.CarResults;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Queries.CarQueries
{
    public class GetAllCarsWithBrandsQuery : CarRequestParameters, IRequest<(List<GetAllCarsWithBrandsQueryResult> result, MetaData metaData)>
    {
        public GetAllCarsWithBrandsQuery(int pageNumber, int pageSize) 
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
