using Application.Features.CQRS.Results.ProvidedServiceResults;
using MediatR;

namespace Application.Features.CQRS.Commands.ProvidedServicesCommands
{
	public class HardRemoveOneProvidedServiceCommand : IRequest<HardRemoveOneProvidedServiceCommandResult>
	{
        public int Id { get; set; }

		public HardRemoveOneProvidedServiceCommand(int id)
		{
			Id = id;
		}
	}
}
