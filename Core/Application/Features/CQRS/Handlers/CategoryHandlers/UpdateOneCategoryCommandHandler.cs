using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionForCategory;
using MediatR;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class UpdateOneCategoryCommandHandler : IRequestHandler<UpdateOneCategoryCommand, UpdateOneCategoryCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public UpdateOneCategoryCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<UpdateOneCategoryCommandResult> Handle(UpdateOneCategoryCommand request, CancellationToken cancellationToken)
		{
			var unchangedEntity = _repositoryManager.CategoryRepository.GetByFilter(true, c => c.Id.Equals(request.Id)).SingleOrDefault();
			if (unchangedEntity is null)
				throw new CategoryNotFoundException(request.Id);
			unchangedEntity.ModifiedDate = DateTime.UtcNow;
			unchangedEntity.Name = request.Name;
			unchangedEntity.IsActive = request.IsActive;
			if (request.IsActive) unchangedEntity.IsDeleted = false; else unchangedEntity.IsDeleted = true;
			await _unitOfWork.CommitAsync();
			return _mapper.Map<UpdateOneCategoryCommandResult>(unchangedEntity);
		}
	}
}
