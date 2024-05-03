using Application.Features.CQRS.Results.LocationResults;
using MediatR;

namespace Application.Features.CQRS.Queries.LocationQueries
{
	public class GetOneLocationByIdQuery : IRequest<GetOneLocationByIdQueryResult>
	{
        public int Id { get; set; }
	
		public GetOneLocationByIdQuery(int id)
		{
			Id = id;
		}
	}
}
