using Application.Features.CQRS.Results.CarDescriptionResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.CarDescriptionCommands
{
	public class UpdateOneCarDescriptionCommand : CarDescriptionForManupulation,IRequest<UpdateOneCarDescriptionCommandResult>
	{
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
