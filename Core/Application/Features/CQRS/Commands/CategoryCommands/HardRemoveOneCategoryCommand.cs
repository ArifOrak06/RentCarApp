using Application.Features.CQRS.Results.CategoryResults;
using MediatR;

namespace Application.Features.CQRS.Commands.CategoryCommands
{
	public class HardRemoveOneCategoryCommand : IRequest<HardRemoveOneCategoryCommandResult>
	{
        public int Id { get; set; }

		public HardRemoveOneCategoryCommand(int id)
		{
			Id = id;
		}
	}
}
