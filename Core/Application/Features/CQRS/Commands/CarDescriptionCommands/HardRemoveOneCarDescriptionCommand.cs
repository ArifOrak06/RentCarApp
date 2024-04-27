using Application.Features.CQRS.Results.CarDescriptionResults;
using MediatR;

namespace Application.Features.CQRS.Commands.CarDescriptionCommands
{
	public class HardRemoveOneCarDescriptionCommand : IRequest<HardRemoveOneCarDescriptionCommandResult>
	{
        public int Id { get; set; }
        public HardRemoveOneCarDescriptionCommand(int id)
        {
            Id = id;
        }
    }
}
