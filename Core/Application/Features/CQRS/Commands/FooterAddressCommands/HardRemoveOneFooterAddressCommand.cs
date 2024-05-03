using Application.Features.CQRS.Results.FooterAdressResults;
using MediatR;

namespace Application.Features.CQRS.Commands.FooterAddressCommands
{
	public class HardRemoveOneFooterAddressCommand : IRequest<HardRemoveOneFooterAddressCommandResult>
	{
        public int Id { get; set; }

		public HardRemoveOneFooterAddressCommand(int id)
		{
			Id = id;
		}
	}
}
