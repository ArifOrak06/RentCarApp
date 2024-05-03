using Application.Features.CQRS.Queries.SocialMedaQueries;
using Application.Features.CQRS.Results.SocialMediaResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Exceptions.Concretes.ExceptionsForSocialMedia;
using MediatR;

namespace Application.Features.CQRS.Handlers.SocialMediaHandlers
{
	public class GetOneSocialMediaByIdQueryHandler : IRequestHandler<GetOneSocialMediaByIdQuery, GetOneSocialMediaByIdQueryResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetOneSocialMediaByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<GetOneSocialMediaByIdQueryResult> Handle(GetOneSocialMediaByIdQuery request, CancellationToken cancellationToken)
		{
			SocialMedia? currentSocialMedia = _repositoryManager.SocialMediaRepository.GetByFilter(false, x => x.Id.Equals(request.Id) && x.IsActive && !x.IsDeleted).SingleOrDefault();
			if (currentSocialMedia == null)
				throw new SocialMediaNotFoundException(request.Id);
			return _mapper.Map<GetOneSocialMediaByIdQueryResult>(currentSocialMedia);
			
		}
	}
}
