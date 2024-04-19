using Application.Features.CQRS.Results.CarResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.CarCommands
{
	public class UpdateOneCarCommand : CarCommandForManipulation,IRequest<UpdateOneCarCommandResult>
	{
        public int Id { get; set; }
        public bool IsActive { get; set; } 


    }
}
