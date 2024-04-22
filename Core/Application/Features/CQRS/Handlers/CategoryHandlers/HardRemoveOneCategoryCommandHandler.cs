using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Repositories;
using Application.UnitOfWork;
using Domain.Exceptions.Concretes.ExceptionForCategory;
using MediatR;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class HardRemoveOneCategoryCommandHandler : IRequestHandler<HardRemoveOneCategoryCommand,HardRemoveOneCategoryCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;

		public HardRemoveOneCategoryCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
		}


		public async Task<HardRemoveOneCategoryCommandResult> Handle(HardRemoveOneCategoryCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.CategoryRepository.GetByFilter(true, x => x.Id == request.Id).SingleOrDefault();
			if (currentEntity == null)
				throw new CategoryNotFoundException(request.Id);
			_repositoryManager.CategoryRepository.Delete(currentEntity);
			await _unitOfWork.CommitAsync();
			return new HardRemoveOneCategoryCommandResult()
			{
				Id = request.Id,
			};
		}
	}
}
