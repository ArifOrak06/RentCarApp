using Application.Features.CQRS.Results.BrandResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.BrandCommands
{
	public class UpdateOneBrandCommand : BrandCommandForManipulation,IRequest<UpdateOneBrandCommandResult>
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
