using Application.Features.CQRS.Results.FooterAdressResults;
using MediatR;

namespace Application.Features.CQRS.Queries.FooterAddressQueries
{
	public class GetOneFooterAddressByIdQuery : IRequest<GetOneFooterAddressByIdQueryResult>
	{
		public int Id { get; set; }

		public GetOneFooterAddressByIdQuery(int id)
		{
			Id = id;
		}
	}
}
