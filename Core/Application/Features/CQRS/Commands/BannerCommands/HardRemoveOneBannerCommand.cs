using Application.Features.CQRS.Results.BannerResults;
using MediatR;

namespace Application.Features.CQRS.Commands.BannerCommands
{
	public class HardRemoveOneBannerCommand : IRequest<HardRemoveOneBannerCommandResult>
	{
        public int Id { get; set; }
        public HardRemoveOneBannerCommand(int id)
        {
            Id = id;
        }
    }
}
