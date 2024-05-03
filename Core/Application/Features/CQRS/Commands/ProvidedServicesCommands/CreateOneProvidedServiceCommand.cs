using Application.Features.CQRS.Results.ProvidedServiceResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.ProvidedServicesCommands
{
	public class CreateOneProvidedServiceCommand : ProvidedServiceCommandForManipulation,IRequest<CreateOneProvidedServiceCommandResult>
	{
	}
}
