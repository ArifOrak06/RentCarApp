using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using Application.UnitOfWork;
using Domain.Exceptions.Concretes.ExceptionForBrand;
using MediatR;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
	public class HardRemoveOneBrandCommandHandler : IRequestHandler<HardRemoveOneBrandCommand, HardRemoveOneBrandCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;

		public HardRemoveOneBrandCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
		}

		public async Task<HardRemoveOneBrandCommandResult> Handle(HardRemoveOneBrandCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.BrandRepository.GetByFilter(true,x => x.Id.Equals(request.Id)).SingleOrDefault();
			if(currentEntity == null) 
				throw new BrandNotFoundException(request.Id);
			_repositoryManager.BrandRepository.Delete(currentEntity);
			await _unitOfWork.CommitAsync();
			return new HardRemoveOneBrandCommandResult(request.Id);
		}
	}
}
