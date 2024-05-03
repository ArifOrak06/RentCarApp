using Application.Features.CQRS.Results.LocationResults;
using MediatR;

namespace Application.Features.CQRS.Queries.LocationQueries
{
	public class GetAllLocationsQuery : IRequest<List<GetAllLocationsQueryResult>>
	{
	}
}
