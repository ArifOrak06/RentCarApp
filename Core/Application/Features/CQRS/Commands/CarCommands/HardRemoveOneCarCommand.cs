using Application.Features.CQRS.Results.CarResults;
using MediatR;

namespace Application.Features.CQRS.Commands.CarCommands
{
	public class HardRemoveOneCarCommand : IRequest<HardRemoveOneCarCommandResult>
	{
        public int Id { get; set; }
        public HardRemoveOneCarCommand(int id)
        {
            Id = id;
        }
    }
}
