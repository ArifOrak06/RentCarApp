using Application.Features.CQRS.Results.BrandResults;
using MediatR;

namespace Application.Features.CQRS.Commands.BrandCommands
{
	public class HardRemoveOneBrandCommand : IRequest<HardRemoveOneBrandCommandResult>
	{
        public int Id { get; set; }

		public HardRemoveOneBrandCommand(int id)
		{
			Id = id;
		}
	}
}
