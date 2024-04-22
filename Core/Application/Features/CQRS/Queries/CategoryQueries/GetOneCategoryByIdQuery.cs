using Application.Features.CQRS.Results.CategoryResults;
using MediatR;

namespace Application.Features.CQRS.Queries.CategoryQueries
{
	public class GetOneCategoryByIdQuery : IRequest<GetOneCategoryByIdQueryResult>
	{
        public int Id { get; set; }

		public GetOneCategoryByIdQuery(int id)
		{
			Id = id;
		}
	}
}
