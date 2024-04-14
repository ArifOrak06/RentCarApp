using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using Application.UnitOfWork;
using Domain.Exceptions.Concretes.ExceptionsForBanner;
using MediatR;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
	public class HardRemoveOneBannerCommandHandler : IRequestHandler<HardRemoveOneBannerCommand, HardRemoveOneBannerCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;

		public HardRemoveOneBannerCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
		}

		public async Task<HardRemoveOneBannerCommandResult> Handle(HardRemoveOneBannerCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.BannerRepository.GetByFilter(false, x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentEntity == null)
				throw new BannerNotFoundException(request.Id);
			_repositoryManager.BannerRepository.Delete(currentEntity);
			await _unitOfWork.CommitAsync();
			return new HardRemoveOneBannerCommandResult
			{
				Id = request.Id,
			};
		}
	}
}
