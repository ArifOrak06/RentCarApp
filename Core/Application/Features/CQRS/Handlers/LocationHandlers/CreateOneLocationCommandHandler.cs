using Application.Features.CQRS.Commands.LocationCommands;
using Application.Features.CQRS.Results.LocationResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.LocationHandlers
{
	public class CreateOneLocationCommandHandler : IRequestHandler<CreateOneLocationCommand, CreateOneLocationCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateOneLocationCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<CreateOneLocationCommandResult> Handle(CreateOneLocationCommand request, CancellationToken cancellationToken)
		{
			var newEntity = _mapper.Map<Location>(request);
			newEntity.CreatedDate = DateTime.UtcNow;
			newEntity.ModifiedDate = DateTime.UtcNow;
			newEntity.IsActive = true;
			newEntity.IsDeleted = false;
			await _repositoryManager.LocationRepository.CreateAsync(newEntity);
			await _unitOfWork.CommitAsync();
			return _mapper.Map<CreateOneLocationCommandResult>(newEntity);

		}
	}
}
