using Application.Features.CQRS.Results.SocialMediaResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.SocialMediaCommands
{
	public class UpdateOneSocialMediaCommand : SocialMediaCommandForManipulation,IRequest<UpdateOneSocialMediaCommandResult>
	{
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
