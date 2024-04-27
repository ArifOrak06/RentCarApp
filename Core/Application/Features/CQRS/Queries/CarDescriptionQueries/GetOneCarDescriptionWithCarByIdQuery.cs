using Application.Features.CQRS.Results.CarDescriptionResults;
using MediatR;

namespace Application.Features.CQRS.Queries.CarDescriptionQueries
{
	public class GetOneCarDescriptionWithCarByIdQuery : IRequest<GetOneCarDescriptionWithCarByIdQueryResult>
	{
        public int Id { get; set; }
        public GetOneCarDescriptionWithCarByIdQuery(int id)
        {
            Id = id;
        }
    }
}
