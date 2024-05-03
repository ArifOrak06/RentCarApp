using Application.Features.CQRS.Commands.LocationCommands;
using Application.Features.CQRS.Results.LocationResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForLocation;
using MediatR;

namespace Application.Features.CQRS.Handlers.LocationHandlers
{
	public class UpdateOneLocationCommandHandler : IRequestHandler<UpdateOneLocationCommand, UpdateOneLocationCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public UpdateOneLocationCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<UpdateOneLocationCommandResult> Handle(UpdateOneLocationCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.LocationRepository.GetByFilter(true, x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentEntity == null)
				throw new LocationNotFoundException(request.Id);
			currentEntity.ModifiedDate = DateTime.UtcNow;
			currentEntity.Name = request.Name;
			currentEntity.IsActive = request.IsActive;
			if (request.IsActive) currentEntity.IsDeleted = false; else currentEntity.IsDeleted = true;
			await _unitOfWork.CommitAsync();
			return _mapper.Map<UpdateOneLocationCommandResult>(currentEntity);
		}
	}
}
