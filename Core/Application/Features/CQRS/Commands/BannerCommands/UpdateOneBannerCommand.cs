using Application.Features.CQRS.Results.BannerResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.BannerCommands
{
    public class UpdateOneBannerCommand : BannerCommandForManipulation, IRequest<UpdateOneBannerCommandResult>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
