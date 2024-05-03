using Application.Features.CQRS.Results.FooterAdressResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.FooterAddressCommands
{
	public class UpdateOneFooterAddressCommand : FooterAddressCommandForManipulation,IRequest<UpdateOneFooterAddressCommandResult>
	{
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
