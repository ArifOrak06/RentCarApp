using Application.Features.CQRS.Results.ContactResults;
using MediatR;

namespace Application.Features.CQRS.Commands.ContactCommands
{
	public class HardRemoveOneContactCommand : IRequest<HardRemoveOneContactCommandResult>
	{
		public int Id { get; set; }

		public HardRemoveOneContactCommand(int id)
		{
			Id = id;
		}
	}
}
