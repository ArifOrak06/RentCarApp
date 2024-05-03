using Application.Features.CQRS.Results.ProvidedServiceResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.ProvidedServicesCommands
{
	public class UpdateOneProvidedServiceCommand : ProvidedServiceCommandForManipulation,IRequest<UpdateOneProvidedServiceCommandResult>
	{
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
