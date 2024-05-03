using Application.Features.CQRS.Commands.SocialMediaCommands;
using Application.Features.CQRS.Results.SocialMediaResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Exceptions.Concretes.ExceptionsForSocialMedia;
using MediatR;

namespace Application.Features.CQRS.Handlers.SocialMediaHandlers
{
	public class UpdateOneSocialMediaCommandHandler : IRequestHandler<UpdateOneSocialMediaCommand, UpdateOneSocialMediaCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateOneSocialMediaCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<UpdateOneSocialMediaCommandResult> Handle(UpdateOneSocialMediaCommand request, CancellationToken cancellationToken)
		{
			SocialMedia? currentSocial = _repositoryManager.SocialMediaRepository.GetByFilter(true, x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentSocial == null)
				throw new SocialMediaNotFoundException(request.Id);
			currentSocial.Url = request.Url;
			currentSocial.Name = request.Name;
			currentSocial.Icon = request.Icon;
			currentSocial.ModifiedDate = DateTime.UtcNow;
			currentSocial.IsActive = request.IsActive;
			if (request.IsActive) currentSocial.IsDeleted = false; else currentSocial.IsDeleted = true;
			await _unitOfWork.CommitAsync();
			return _mapper.Map<UpdateOneSocialMediaCommandResult>(currentSocial);

			
		}
	}
}
