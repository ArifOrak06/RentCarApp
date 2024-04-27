using Application.Features.CQRS.Commands.CarDescriptionCommands;
using Application.Features.CQRS.Results.CarDescriptionResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForCarDescription;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
	public class UpdateOneCarDescriptionCommandHandler : IRequestHandler<UpdateOneCarDescriptionCommand, UpdateOneCarDescriptionCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public UpdateOneCarDescriptionCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<UpdateOneCarDescriptionCommandResult> Handle(UpdateOneCarDescriptionCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.CarDescriptionRepository.GetByFilter(true, x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentEntity == null)
				throw new CarDescriptionNotFoundException(request.Id);
			currentEntity.CarId = request.CarId;
			currentEntity.Description = request.Description;
			currentEntity.IsActive = request.IsActive;
			currentEntity.ModifiedDate = DateTime.UtcNow;
			if (request.IsActive) currentEntity.IsDeleted = false; else currentEntity.IsDeleted = true;
			await _unitOfWork.CommitAsync();
			return _mapper.Map<UpdateOneCarDescriptionCommandResult>(currentEntity);
		}
	}
}
