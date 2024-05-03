using Application.Features.CQRS.Commands.ProvidedServicesCommands;
using Application.Features.CQRS.Results.ProvidedServiceResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.ProvidedServiceHandlers
{
	public class CreateOneProvidedServiceCommandHandler : IRequestHandler<CreateOneProvidedServiceCommand, CreateOneProvidedServiceCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateOneProvidedServiceCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<CreateOneProvidedServiceCommandResult> Handle(CreateOneProvidedServiceCommand request, CancellationToken cancellationToken)
		{
			ProvidedService? newService = _mapper.Map<ProvidedService>(request);
			newService.CreatedDate = DateTime.UtcNow;
			newService.ModifiedDate = DateTime.UtcNow;
			newService.IsActive = true;
			newService.IsDeleted = false;
			await _repositoryManager.ProvidedServiceRepository.CreateAsync(newService);
			await _unitOfWork.CommitAsync();
			return _mapper.Map<CreateOneProvidedServiceCommandResult>(newService);
			
		}
	}
}
