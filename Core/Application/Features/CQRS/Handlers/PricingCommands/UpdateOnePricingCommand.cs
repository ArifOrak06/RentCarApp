using Application.Features.CQRS.Results.PricingResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingCommands
{
	public class UpdateOnePricingCommand : PricingCommandForManipulation,IRequest<UpdateOnePricingCommandResult>
	{
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
