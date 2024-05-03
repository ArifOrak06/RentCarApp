using Application.Features.CQRS.Results.SocialMediaResults;
using MediatR;

namespace Application.Features.CQRS.Queries.SocialMedaQueries
{
	public class GetAllSocialMediasQuery : IRequest<List<GetAllSocialMediasQueryResult>>
	{
		public int Id { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }
		public string Icon { get; set; }
	}
}
