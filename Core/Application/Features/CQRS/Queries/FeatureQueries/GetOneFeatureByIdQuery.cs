using Application.Features.CQRS.Results.FeatureResults;
using MediatR;

namespace Application.Features.CQRS.Queries.FeatureQueries
{
	public class GetOneFeatureByIdQuery : IRequest<GetOneFeatureByIdQueryResult>
	{
		public int Id { get; set; }
        public GetOneFeatureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
