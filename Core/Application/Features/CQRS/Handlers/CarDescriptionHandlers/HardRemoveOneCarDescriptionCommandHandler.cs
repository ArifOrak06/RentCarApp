using Application.Features.CQRS.Commands.CarDescriptionCommands;
using Application.Features.CQRS.Results.CarDescriptionResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForCarDescription;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
	public class HardRemoveOneCarDescriptionCommandHandler : IRequestHandler<HardRemoveOneCarDescriptionCommand, HardRemoveOneCarDescriptionCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public HardRemoveOneCarDescriptionCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<HardRemoveOneCarDescriptionCommandResult> Handle(HardRemoveOneCarDescriptionCommand request, CancellationToken cancellationToken)
		{

			var currentEntity = _repositoryManager.CarDescriptionRepository.GetByFilter(true,x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentEntity == null)
				throw new CarDescriptionNotFoundException(request.Id);
			_repositoryManager.CarDescriptionRepository.Delete(currentEntity);
			await _unitOfWork.CommitAsync();
			return new HardRemoveOneCarDescriptionCommandResult()
			{
				Id = request.Id
			};
		}
	}
}
