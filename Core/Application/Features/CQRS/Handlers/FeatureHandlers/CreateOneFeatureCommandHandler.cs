using Application.Features.CQRS.Commands.FeatureCommands;
using Application.Features.CQRS.Results.FeatureResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.FeatureHandlers
{
	public class CreateOneFeatureCommandHandler : IRequestHandler<CreateOneFeatureCommand, CreateOneFeatureCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateOneFeatureCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<CreateOneFeatureCommandResult> Handle(CreateOneFeatureCommand request, CancellationToken cancellationToken)
		{
			var newEntity = _mapper.Map<Feature>(request);
			newEntity.IsActive = true;
			newEntity.IsDeleted = false;
			newEntity.Name = request.Name;
			newEntity.CreatedDate = DateTime.UtcNow;
			newEntity.ModifiedDate = DateTime.UtcNow;
			await _repositoryManager.FeatureRepository.CreateAsync(newEntity);
			await _unitOfWork.CommitAsync();
			return _mapper.Map<CreateOneFeatureCommandResult>(newEntity);
		}
	}
}
