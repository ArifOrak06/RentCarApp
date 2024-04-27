using Application.Features.CQRS.Commands.FeatureCommands;
using Application.Features.CQRS.Results.FeatureResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForFeature;
using MediatR;

namespace Application.Features.CQRS.Handlers.FeatureHandlers
{
	public class UpdateOneFeatureCommandHandler : IRequestHandler<UpdateOneFeatureCommand, UpdateOneFeatureCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateOneFeatureCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<UpdateOneFeatureCommandResult> Handle(UpdateOneFeatureCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.FeatureRepository.GetByFilter(true,x => x.Id == request.Id).SingleOrDefault();
			if (currentEntity == null)
				throw new FeatureNotFoundException(request.Id);
			currentEntity.ModifiedDate = DateTime.UtcNow;
			currentEntity.IsActive = request.IsActive;
			currentEntity.Name = request.Name;
			if (request.IsActive) currentEntity.IsDeleted = true; else currentEntity.IsDeleted = false;
			await _unitOfWork.CommitAsync();
			return _mapper.Map<UpdateOneFeatureCommandResult>(currentEntity);

		}
	}
}
