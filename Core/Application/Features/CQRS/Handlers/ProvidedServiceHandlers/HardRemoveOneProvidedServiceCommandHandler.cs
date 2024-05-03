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
	public class HardRemoveOneProvidedServiceCommandHandler : IRequestHandler<HardRemoveOneProvidedServiceCommand, HardRemoveOneProvidedServiceCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public HardRemoveOneProvidedServiceCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<HardRemoveOneProvidedServiceCommandResult> Handle(HardRemoveOneProvidedServiceCommand request, CancellationToken cancellationToken)
		{
			ProvidedService? currentService = _repositoryManager.ProvidedServiceRepository.GetByFilter(true,x=> x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentService == null)
				throw new ProvidedServiceNotFoundException(request.Id);
			_repositoryManager.ProvidedServiceRepository.Delete(currentService);
			await _unitOfWork.CommitAsync();
			return new HardRemoveOneProvidedServiceCommandResult(request.Id);
		}
	}
}
