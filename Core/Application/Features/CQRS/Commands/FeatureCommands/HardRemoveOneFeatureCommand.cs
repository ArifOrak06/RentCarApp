using Application.Features.CQRS.Results.FeatureResults;
using MediatR;

namespace Application.Features.CQRS.Commands.FeatureCommands
{
	public class HardRemoveOneFeatureCommand : IRequest<HardRemoveOneFeatureCommandResult>
	{
        public int Id { get; set; }

		public HardRemoveOneFeatureCommand(int id)
		{
			Id = id;
		}
	}
}
