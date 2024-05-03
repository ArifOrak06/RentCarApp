using Application.Features.CQRS.Results.FooterAdressResults;
using MediatR;

namespace Application.Features.CQRS.Queries.FooterAddressQueries
{
	public class GetAllFooterAddressQuery : IRequest<List<GetAllFooterAddressQueryResult>>
	{
	}
}
