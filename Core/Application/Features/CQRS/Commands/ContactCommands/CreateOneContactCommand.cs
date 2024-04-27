using Application.Features.CQRS.Results.ContactResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.ContactCommands
{
	public class CreateOneContactCommand : ContactCommandForManipulation,IRequest<CreateOneContactCommandResult>
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }

	}
}
