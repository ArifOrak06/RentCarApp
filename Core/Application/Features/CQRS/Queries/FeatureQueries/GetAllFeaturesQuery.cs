using Application.Features.CQRS.Results.FeatureResults;
using MediatR;

namespace Application.Features.CQRS.Queries.FeatureQueries
{
	public class GetAllFeaturesQuery : IRequest<List<GetAllFeaturesQueryResult>>
	{
	}
}
