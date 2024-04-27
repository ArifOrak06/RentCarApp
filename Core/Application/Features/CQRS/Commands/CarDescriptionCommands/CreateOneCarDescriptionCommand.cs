using Application.Features.CQRS.Results.CarDescriptionResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.CarDescriptionCommands
{
	public class CreateOneCarDescriptionCommand : CarDescriptionForManupulation, IRequest<CreateOneCarDescriptionCommandResult>
	{
	}
}
