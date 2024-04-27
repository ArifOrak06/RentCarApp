using Application.Features.CQRS.Commands.ContactCommands;
using Application.Features.CQRS.Results.ContactResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForContact;
using MediatR;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
	public class HardRemoveOneContactCommandHandler : IRequestHandler<HardRemoveOneContactCommand, HardRemoveOneContactCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;

		public HardRemoveOneContactCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
		}

		public async Task<HardRemoveOneContactCommandResult> Handle(HardRemoveOneContactCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.ContactRepository.GetByFilter(true,x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentEntity is null)
				throw new ContactNotFoundException(request.Id);
			_repositoryManager.ContactRepository.Delete(currentEntity);
			await _unitOfWork.CommitAsync();
			return new HardRemoveOneContactCommandResult(request.Id);
		
		}
	}
}
