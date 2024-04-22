using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class CreateOneCategoryCommandHandler : IRequestHandler<CreateOneCategoryCommand, CreateOneCategoryCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateOneCategoryCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<CreateOneCategoryCommandResult> Handle(CreateOneCategoryCommand request, CancellationToken cancellationToken)
		{
			var newCategory = _mapper.Map<Category>(request);
			newCategory.CreatedDate = DateTime.UtcNow;
			newCategory.ModifiedDate = DateTime.UtcNow;
			newCategory.IsActive = true;
			newCategory.IsDeleted = false;
			await _repositoryManager.CategoryRepository.CreateAsync(newCategory);
			await _unitOfWork.CommitAsync();
			return _mapper.Map<CreateOneCategoryCommandResult>(newCategory);

			
		}
	}
}
