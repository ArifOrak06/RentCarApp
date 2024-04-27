using Application.Features.CQRS.Commands.FeatureCommands;
using Application.Features.CQRS.Results.FeatureResults;
using Application.Repositories;
using Application.UnitOfWork;
using Domain.Exceptions.Concretes.ExceptionsForFeature;
using MediatR;

namespace Application.Features.CQRS.Handlers.FeatureHandlers
{
	public class HardRemoveOneFeatureCommandHandler : IRequestHandler<HardRemoveOneFeatureCommand, HardRemoveOneFeatureCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;

		public HardRemoveOneFeatureCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
		}

		public async Task<HardRemoveOneFeatureCommandResult> Handle(HardRemoveOneFeatureCommand request, CancellationToken cancellationToken)
		{
			var entity = _repositoryManager.FeatureRepository.GetByFilter(true, x => x.Id == request.Id).SingleOrDefault();
			if (entity == null)
				throw new FeatureNotFoundException(request.Id);
			_repositoryManager.FeatureRepository.Delete(entity);
			await _unitOfWork.CommitAsync();
			return new HardRemoveOneFeatureCommandResult(request.Id);
		}
	}
}
