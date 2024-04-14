using Application.Features.CQRS.Results.BannerResults;
using MediatR;

namespace Application.Features.CQRS.Commands.BannerCommands
{
	public class SoftRemoveOneBannerCommand : IRequest<SoftRemoveOneBannerCommandResult>
	{
        public int Id { get; set; }
        public SoftRemoveOneBannerCommand(int id)
        {
            Id = id;
        }
    }
}
