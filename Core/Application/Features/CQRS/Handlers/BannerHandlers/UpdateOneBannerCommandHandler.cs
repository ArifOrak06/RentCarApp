using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForBanner;
using MediatR;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
	public class UpdateOneBannerCommandHandler : IRequestHandler<UpdateOneBannerCommand, UpdateOneBannerCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateOneBannerCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<UpdateOneBannerCommandResult> Handle(UpdateOneBannerCommand request, CancellationToken cancellationToken)
		{
			var currentBanner = _repositoryManager.BannerRepository.GetByFilter(true,x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentBanner == null)
				throw new BannerNotFoundException(request.Id);
			currentBanner.ModifiedDate = DateTime.UtcNow;
			currentBanner.IsActive = request.IsActive;
			if (request.IsActive) currentBanner.IsDeleted = false; 
			else currentBanner.IsDeleted = true;
			
			currentBanner.Description = request.Description;
			currentBanner.VideoDescription = request.VideoDescription;
			currentBanner.VideoUrl = request.VideoUrl;
			await _unitOfWork.CommitAsync();
			return _mapper.Map<UpdateOneBannerCommandResult>(currentBanner);

		}
	}
}
