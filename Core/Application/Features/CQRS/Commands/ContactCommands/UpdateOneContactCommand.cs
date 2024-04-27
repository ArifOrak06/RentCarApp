using Application.Features.CQRS.Results.ContactResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.ContactCommands
{
	public class UpdateOneContactCommand : ContactCommandForManipulation,IRequest<UpdateOneContactCommandResult>
	{
        public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public bool IsActive { get; set; }
	}
}
