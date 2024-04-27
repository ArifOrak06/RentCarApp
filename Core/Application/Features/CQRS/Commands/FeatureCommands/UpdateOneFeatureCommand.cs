using Application.Features.CQRS.Results.FeatureResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.FeatureCommands
{
	public class UpdateOneFeatureCommand : FeatureForManupulation,IRequest<UpdateOneFeatureCommandResult>
	{
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
