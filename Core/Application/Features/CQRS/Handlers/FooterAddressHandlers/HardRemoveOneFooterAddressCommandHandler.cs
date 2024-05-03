using Application.Features.CQRS.Commands.FooterAddressCommands;
using Application.Features.CQRS.Results.FooterAdressResults;
using Application.Repositories;
using Application.UnitOfWork;
using Domain.Exceptions.Concretes.ExceptionsForFooterAddress;
using MediatR;

namespace Application.Features.CQRS.Handlers.FooterAddressHandlers
{
	public class HardRemoveOneFooterAddressCommandHandler : IRequestHandler<HardRemoveOneFooterAddressCommand, HardRemoveOneFooterAddressCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;

		public HardRemoveOneFooterAddressCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
		}

		public async Task<HardRemoveOneFooterAddressCommandResult> Handle(HardRemoveOneFooterAddressCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.FooterAddressRepository.GetByFilter(true,x => x.Id == request.Id).SingleOrDefault();
            if (currentEntity is null)
				throw new FooterAddressNotFoundException(request.Id); 
			_repositoryManager.FooterAddressRepository.Delete(currentEntity);
			await _unitOfWork.CommitAsync();
			return new HardRemoveOneFooterAddressCommandResult(request.Id);
		}
	}
}
