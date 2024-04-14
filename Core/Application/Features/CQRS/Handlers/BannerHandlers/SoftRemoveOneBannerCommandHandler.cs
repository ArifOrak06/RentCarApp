using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using Application.UnitOfWork;
using Domain.Exceptions.Concretes.ExceptionsForBanner;
using MediatR;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
	public class SoftRemoveOneBannerCommandHandler : IRequestHandler<SoftRemoveOneBannerCommand, SoftRemoveOneBannerCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;

		public SoftRemoveOneBannerCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
		}

		public async Task<SoftRemoveOneBannerCommandResult> Handle(SoftRemoveOneBannerCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.BannerRepository.GetByFilter(true,x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentEntity != null)
				throw new BannerNotFoundException(request.Id);
			currentEntity.IsActive = false;
			currentEntity.IsDeleted = true;
			currentEntity.ModifiedDate = DateTime.UtcNow;
			await _unitOfWork.CommitAsync();
			return new SoftRemoveOneBannerCommandResult
			{
				Id = request.Id,
				IsActive = currentEntity.IsActive,
				IsDeleted = currentEntity.IsDeleted
			};
			
		}
	}
}
