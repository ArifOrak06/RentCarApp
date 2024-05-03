using Application.Features.CQRS.Commands.LocationCommands;
using Application.Features.CQRS.Results.LocationResults;
using Application.Repositories;
using Application.UnitOfWork;
using Domain.Exceptions.Concretes.ExceptionsForLocation;
using MediatR;

namespace Application.Features.CQRS.Handlers.LocationHandlers
{
	public class HardRemoveOneLocationCommandHandler : IRequestHandler<HardRemoveOneLocationCommand, HardRemoveOneLocationCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;

		public HardRemoveOneLocationCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
		}

		public async Task<HardRemoveOneLocationCommandResult> Handle(HardRemoveOneLocationCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.LocationRepository.GetByFilter(true,x => x.Id == request.Id).SingleOrDefault();
			if (currentEntity == null)
				throw new LocationNotFoundException(request.Id);
			_repositoryManager.LocationRepository.Delete(currentEntity);
			await _unitOfWork.CommitAsync();
			return new HardRemoveOneLocationCommandResult(request.Id);
		
		}
	}
}
