using Application.Features.CQRS.Results.FooterAdressResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.FooterAddressCommands
{
	public class CreateOneFooterAddressCommand :FooterAddressCommandForManipulation,IRequest<CreateOneFooterAddressCommandResult>
	{

	}
}
