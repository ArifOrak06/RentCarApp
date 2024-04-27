using Application.Features.CQRS.Results.ContactResults;
using MediatR;

namespace Application.Features.CQRS.Queries.ContactQueries
{
	public class GetAllContactsQuery : IRequest<List<GetAllContactsQueryResult>>
	{
	}
}
