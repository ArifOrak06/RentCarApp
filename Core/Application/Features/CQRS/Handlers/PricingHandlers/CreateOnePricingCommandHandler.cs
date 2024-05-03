using Application.Features.CQRS.Handlers.PricingCommands;
using Application.Features.CQRS.Results.PricingResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingHandlers
{
	public class CreateOnePricingCommandHandler : IRequestHandler<CreateOnePricingCommand, CreateOnePricingCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CreateOnePricingCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<CreateOnePricingCommandResult> Handle(CreateOnePricingCommand request, CancellationToken cancellationToken)
		{
			Pricing? newPricing = _mapper.Map<Pricing>(request);
			newPricing.CreatedDate = DateTime.UtcNow;
			newPricing.ModifiedDate = DateTime.UtcNow;
			newPricing.IsActive = true;
			newPricing.IsDeleted = false;
			await _repositoryManager.PricingRepository.CreateAsync(newPricing);
			await _unitOfWork.CommitAsync();
			return _mapper.Map<CreateOnePricingCommandResult>(newPricing);

		}
	}
}
