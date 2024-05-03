using Application.Features.CQRS.Commands.ProvidedServicesCommands;
using Application.Features.CQRS.Results.ProvidedServiceResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Exceptions.Concretes.ExceptionsForProvidedService;
using MediatR;

namespace Application.Features.CQRS.Handlers.ProvidedServiceHandlers
{
	public class UpdateOneProvidedServiceCommandHandler : IRequestHandler<UpdateOneProvidedServiceCommand, UpdateOneProvidedServiceCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateOneProvidedServiceCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<UpdateOneProvidedServiceCommandResult> Handle(UpdateOneProvidedServiceCommand request, CancellationToken cancellationToken)
		{
			ProvidedService? currentService = _repositoryManager.ProvidedServiceRepository.GetByFilter(true, x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentService == null)
				throw new ProvidedServiceNotFoundException(request.Id);
			currentService.Description = request.Description;
			currentService.IsActive = request.IsActive;
			currentService.Title = request.Title;
			currentService.IconUrl = request.IconUrl;
			currentService.ModifiedDate = DateTime.UtcNow;
			if(request.IsActive) currentService.IsDeleted = true; else currentService.IsDeleted = false;
			await _unitOfWork.CommitAsync();
			return _mapper.Map<UpdateOneProvidedServiceCommandResult>(currentService);

		}
	}
}
