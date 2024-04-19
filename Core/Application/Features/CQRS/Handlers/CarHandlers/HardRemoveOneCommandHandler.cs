using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForCar;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
	public class HardRemoveOneCommandHandler : IRequestHandler<HardRemoveOneCarCommand, HardRemoveOneCarCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public HardRemoveOneCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<HardRemoveOneCarCommandResult> Handle(HardRemoveOneCarCommand request, CancellationToken cancellationToken)
		{
			var deletedEntity = _repositoryManager.CarRepository.GetByFilter(true,x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (deletedEntity is null)
				throw new CarNotFoundException(request.Id);
			_repositoryManager.CarRepository.Delete(deletedEntity);
			await _unitOfWork.CommitAsync();
			return new HardRemoveOneCarCommandResult(request.Id);
		}
	}
}
