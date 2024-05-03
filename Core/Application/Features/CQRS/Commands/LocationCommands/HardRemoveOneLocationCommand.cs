using Application.Features.CQRS.Results.LocationResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.LocationCommands
{
	public class HardRemoveOneLocationCommand : LocationCommandForManipulation,IRequest<HardRemoveOneLocationCommandResult>
	{
        public int Id { get; set; }
        public HardRemoveOneLocationCommand(int id)
        {
            Id  = id;
        }
    }
}
