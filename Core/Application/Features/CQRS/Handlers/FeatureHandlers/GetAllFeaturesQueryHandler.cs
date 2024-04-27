using Application.Features.CQRS.Queries.FeatureQueries;
using Application.Features.CQRS.Results.FeatureResults;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CQRS.Handlers.FeatureHandlers
{
	public class GetAllFeaturesQueryHandler : IRequestHandler<GetAllFeaturesQuery, List<GetAllFeaturesQueryResult>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetAllFeaturesQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<List<GetAllFeaturesQueryResult>> Handle(GetAllFeaturesQuery request, CancellationToken cancellationToken)
		{
			var entities = await _repositoryManager.FeatureRepository.GetAllAsync(false, x => x.IsActive && !x.IsDeleted, x => x.CarFeatures);
			if (!entities.Any())
				throw new Exception("Sistemde kayıtlı Feature varlığı bulunmamaktadır.");
			return _mapper.Map<List<GetAllFeaturesQueryResult>>(entities);
		
		}
	}
}
