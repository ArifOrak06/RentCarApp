using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionForBrand;
using MediatR;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
	public class UpdateOneBrandCommandHandler : IRequestHandler<UpdateOneBrandCommand, UpdateOneBrandCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public UpdateOneBrandCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<UpdateOneBrandCommandResult> Handle(UpdateOneBrandCommand request, CancellationToken cancellationToken)
		{
			var unchangedEntity = _repositoryManager.BrandRepository.GetByFilter(true,x => x.Id ==request.Id).SingleOrDefault();
			if(unchangedEntity is null)
				throw new BrandNotFoundException(request.Id);
			unchangedEntity.ModifiedDate = DateTime.UtcNow;
			unchangedEntity.Name = request.Name;
			unchangedEntity.IsActive = request.IsActive;
			if (request.IsActive) unchangedEntity.IsDeleted = false; else unchangedEntity.IsDeleted = true;
			await _unitOfWork.CommitAsync();
			return _mapper.Map<UpdateOneBrandCommandResult>(unchangedEntity);

		}
	}
}
