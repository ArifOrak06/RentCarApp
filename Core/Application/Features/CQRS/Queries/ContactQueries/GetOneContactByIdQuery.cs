using Application.Features.CQRS.Results.ContactResults;
using MediatR;

namespace Application.Features.CQRS.Queries.ContactQueries
{
	public class GetOneContactByIdQuery : IRequest<GetOneContactByIdQueryResult>
	{
        public int Id { get; set; }
        public GetOneContactByIdQuery(int id)
        {
            Id = id;
        }
    }
}
