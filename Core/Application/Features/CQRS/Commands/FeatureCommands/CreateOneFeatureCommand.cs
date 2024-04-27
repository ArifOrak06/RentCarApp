using Application.Features.CQRS.Results.FeatureResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.FeatureCommands
{
	public class CreateOneFeatureCommand :FeatureForManupulation, IRequest<CreateOneFeatureCommandResult>
	{
	}
}
