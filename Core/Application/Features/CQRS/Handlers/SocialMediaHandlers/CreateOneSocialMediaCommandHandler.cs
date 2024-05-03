using Application.Features.CQRS.Commands.SocialMediaCommands;
using Application.Features.CQRS.Results.SocialMediaResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.SocialMediaHandlers
{
	public class CreateOneSocialMediaCommandHandler : IRequestHandler<CreateOneSocialMediaCommand, CreateOneSocialMediaCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateOneSocialMediaCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<CreateOneSocialMediaCommandResult> Handle(CreateOneSocialMediaCommand request, CancellationToken cancellationToken)
		{
			
			SocialMedia? newSocial = _mapper.Map<SocialMedia>(request);
			newSocial.CreatedDate = DateTime.UtcNow;
			newSocial.ModifiedDate = DateTime.UtcNow;
			newSocial.IsActive = true;
			newSocial.IsDeleted = false;
			await _repositoryManager.SocialMediaRepository.CreateAsync(newSocial);
			await _unitOfWork.CommitAsync();
			return _mapper.Map<CreateOneSocialMediaCommandResult>(newSocial);
		}
	}
}
