using Application.Features.CQRS.Results.SocialMediaResults;
using MediatR;

namespace Application.Features.CQRS.Commands.SocialMediaCommands
{
	public class HardRemoveOneSocialMediaCommand : IRequest<HardRemoveOneSocialMediaCommandResult>
	{
        public int Id { get; set; }

		public HardRemoveOneSocialMediaCommand(int id)
		{
			Id = id;
		}
	}
}
