using Application.Features.CQRS.Handlers.PricingCommands;
using Application.Features.CQRS.Results.PricingResults;
using Application.Repositories;
using Application.UnitOfWork;
using Domain.Exceptions.Concretes.ExceptionsForPricing;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingHandlers
{
	public class HardRemoveOnePricingCommandHandler : IRequestHandler<HardRemoveOnePricingCommand, HardRemoveOnePricingCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;

		public HardRemoveOnePricingCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
		}

		public async Task<HardRemoveOnePricingCommandResult> Handle(HardRemoveOnePricingCommand request, CancellationToken cancellationToken)
		{
			var currentEntity  = _repositoryManager.PricingRepository.GetByFilter(true,x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentEntity == null)
				throw new PricingNotFoundException(request.Id);
			_repositoryManager.PricingRepository.Delete(currentEntity);
			await _unitOfWork.CommitAsync();
			return new HardRemoveOnePricingCommandResult(request.Id);
		}
	}
}
