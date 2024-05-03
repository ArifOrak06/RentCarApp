using Application.Features.CQRS.Results.PricingResults;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingCommands
{
	public class HardRemoveOnePricingCommand : IRequest<HardRemoveOnePricingCommandResult>
	{
        public int Id { get; set; }

		public HardRemoveOnePricingCommand(int id)
		{
			Id = id;
		}
	}
}
