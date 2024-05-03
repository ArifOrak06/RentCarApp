using Application.Features.CQRS.Queries.SocialMedaQueries;
using Application.Features.CQRS.Results.SocialMediaResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.SocialMediaHandlers
{
	public class GetAllSocialMediasQueryHandler : IRequestHandler<GetAllSocialMediasQuery, List<GetAllSocialMediasQueryResult>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetAllSocialMediasQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<List<GetAllSocialMediasQueryResult>> Handle(GetAllSocialMediasQuery request, CancellationToken cancellationToken)
		{
			List<SocialMedia> socialMedias = await _repositoryManager.SocialMediaRepository.GetAllAsync(false, x => x.IsActive && !x.IsDeleted);
			if (!socialMedias.Any())
				throw new Exception("Sistemde kayıtlı sosyal media nesnesi bulunmamaktadır.");
			return _mapper.Map<List<GetAllSocialMediasQueryResult>>(socialMedias); 
			
		}
	}
}
