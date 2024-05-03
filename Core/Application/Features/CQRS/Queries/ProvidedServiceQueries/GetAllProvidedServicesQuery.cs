using Application.Features.CQRS.Results.ProvidedServiceResults;
using MediatR;

namespace Application.Features.CQRS.Queries.ProvidedServiceQueries
{
	public class GetAllProvidedServicesQuery : IRequest<List<GetAllProvidedServicesQueryResult>>
	{
	}
}
