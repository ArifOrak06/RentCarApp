using Application.Features.CQRS.Results.CarDescriptionResults;
using MediatR;

namespace Application.Features.CQRS.Queries.CarDescriptionQueries
{
	public class GetAllCarDescriptionsWithCarsQuery : IRequest<List<GetAllCarDescriptionsWithCarsQueryResult>>
	{
	}
}
