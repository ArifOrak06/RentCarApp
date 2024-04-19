using Application.Features.CQRS.Results.BrandResults;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Queries.BrandQueries
{
	public class GetAllBrandsWithCarsQuery : BrandRequestParameters, IRequest<(List<GetAllBrandsWithCarsQueryResult> result, MetaData metaData)>
	{
		public GetAllBrandsWithCarsQuery(int pageNumber, int pageSize) : base(pageNumber, pageSize)
		{
		}
	}
}
