using Application.Features.CQRS.Results.LocationResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.LocationCommands
{
	public class CreateOneLocationCommand : LocationCommandForManipulation,IRequest<CreateOneLocationCommandResult>
	{

	}
}
