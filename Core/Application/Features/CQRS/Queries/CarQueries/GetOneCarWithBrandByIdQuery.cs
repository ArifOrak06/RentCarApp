using Application.Features.CQRS.Results.CarResults;
using MediatR;

namespace Application.Features.CQRS.Queries.CarQueries
{
	public class GetOneCarWithBrandByIdQuery :IRequest<GetOneCarWithBrandByIdQueryResult>
	{
        public int Id { get; set; }
        public GetOneCarWithBrandByIdQuery(int id)
        {
            Id = id;
        }
    }
}
