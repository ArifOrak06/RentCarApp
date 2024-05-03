using Application.Features.CQRS.Results.ProvidedServiceResults;
using MediatR;

namespace Application.Features.CQRS.Queries.ProvidedServiceQueries
{
	public class GetOneProvidedServiceByIdQuery : IRequest<GetOneProvidedServiceByIdQueryResult>
	{
        public int Id { get; set; }

		public GetOneProvidedServiceByIdQuery(int id)
		{
			Id = id;
		}
	}
}
