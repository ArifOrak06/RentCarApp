using Application.Features.CQRS.Handlers.PricingCommands;
using Application.Features.CQRS.Results.PricingResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForPricing;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingHandlers
{
	public class UpdateOnePricingCommandHandler : IRequestHandler<UpdateOnePricingCommand, UpdateOnePricingCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateOnePricingCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<UpdateOnePricingCommandResult> Handle(UpdateOnePricingCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.PricingRepository.GetByFilter(true,x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentEntity == null) 
				throw new PricingNotFoundException(request.Id);
			currentEntity.Name = request.Name;
			currentEntity.ModifiedDate = DateTime.UtcNow;
			currentEntity.IsActive = request.IsActive;
			if (request.IsActive) currentEntity.IsDeleted = false; else currentEntity.IsDeleted = true;
			await _unitOfWork.CommitAsync();
			return _mapper.Map<UpdateOnePricingCommandResult>(currentEntity);
		}
	}
}
