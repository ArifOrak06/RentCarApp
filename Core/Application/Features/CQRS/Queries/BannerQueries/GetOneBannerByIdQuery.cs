using Application.Features.CQRS.Results.BannerResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForQueries;
using MediatR;

namespace Application.Features.CQRS.Queries.BannerQueries
{
	public class GetOneBannerByIdQuery : QueryForManipulation,IRequest<GetOneBannerByIdQueryResult>
	{
        public GetOneBannerByIdQuery(int id) : base(id)
        {
            
        }
    }
}
