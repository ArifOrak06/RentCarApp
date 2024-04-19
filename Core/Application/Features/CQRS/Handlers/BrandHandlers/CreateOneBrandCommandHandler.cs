using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
	public class CreateOneBrandCommandHandler : IRequestHandler<CreateOneBrandCommand, CreateOneBrandCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateOneBrandCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<CreateOneBrandCommandResult> Handle(CreateOneBrandCommand request, CancellationToken cancellationToken)
		{
			Brand? newBrand = _mapper.Map<Brand>(request);
			newBrand.CreatedDate = DateTime.UtcNow;
			newBrand.ModifiedDate = DateTime.UtcNow;
			newBrand.IsActive = true;
			newBrand.IsDeleted = false;

			await _repositoryManager.BrandRepository.CreateAsync(newBrand);
			await _unitOfWork.CommitAsync();
			return _mapper.Map<CreateOneBrandCommandResult>(newBrand);
			
		}
	}
}
