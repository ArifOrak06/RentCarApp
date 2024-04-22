using Application.Features.CQRS.Results.CategoryResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.CategoryCommands
{
	public class UpdateOneCategoryCommand : CategoryForManipulation, IRequest<UpdateOneCategoryCommandResult>
	{
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
