using Application.Features.CQRS.Results.CategoryResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.CategoryCommands
{
	public class CreateOneCategoryCommand : CategoryForManipulation,IRequest<CreateOneCategoryCommandResult>
	{
	}
}
