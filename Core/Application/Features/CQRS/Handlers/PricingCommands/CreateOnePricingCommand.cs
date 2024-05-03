using Application.Features.CQRS.Results.PricingResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingCommands
{
	public class CreateOnePricingCommand :PricingCommandForManipulation, IRequest<CreateOnePricingCommandResult>
	{
	}
}
