using Application.Features.CQRS.Results.BannerResults;
using MediatR;

namespace Application.Features.CQRS.Queries.BannerQueries
{
	public class GetAllBannersQuery : IRequest<IEnumerable<GetAllBannersQueryResult>>
	{
	}
}
