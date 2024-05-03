using Application.Features.CQRS.Commands.SocialMediaCommands;
using Application.Features.CQRS.Results.SocialMediaResults;
using Application.Repositories;
using Application.UnitOfWork;
using Domain.Entities.Concrete;
using Domain.Exceptions.Concretes.ExceptionsForSocialMedia;
using MediatR;

namespace Application.Features.CQRS.Handlers.SocialMediaHandlers
{
	public class HardRemoveOneSocialMediaCommandHandler : IRequestHandler<HardRemoveOneSocialMediaCommand, HardRemoveOneSocialMediaCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;

		public HardRemoveOneSocialMediaCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
		}

		public async Task<HardRemoveOneSocialMediaCommandResult> Handle(HardRemoveOneSocialMediaCommand request, CancellationToken cancellationToken)
		{
			SocialMedia? currentSocial = _repositoryManager.SocialMediaRepository.GetByFilter(true,x => x.Id == request.Id).SingleOrDefault();
			if (currentSocial == null)
				throw new SocialMediaNotFoundException(request.Id);
			_repositoryManager.SocialMediaRepository.Delete(currentSocial);
			await _unitOfWork.CommitAsync();
			return new HardRemoveOneSocialMediaCommandResult(request.Id);

		}
	}
}
