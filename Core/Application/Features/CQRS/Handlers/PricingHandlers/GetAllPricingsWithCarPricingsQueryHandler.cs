using Application.Features.CQRS.Queries.PricingQueries;
using Application.Features.CQRS.Results.PricingResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingHandlers
{
	public class GetAllPricingsWithCarPricingsQueryHandler : IRequestHandler<GetAllPricingsWithCarPricingsQuery, (List<GetAllPricingsWithCarPricingsQueryResult> result, MetaData metaData)>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetAllPricingsWithCarPricingsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<(List<GetAllPricingsWithCarPricingsQueryResult> result, MetaData metaData)> Handle(GetAllPricingsWithCarPricingsQuery request, CancellationToken cancellationToken)
		{
			var entities = await _repositoryManager.PricingRepository.GetAllPricingAsync(false, request, x => x.IsActive && !x.IsDeleted, x => x.CarPricings);
			return (result: _mapper.Map<List<GetAllPricingsWithCarPricingsQueryResult>>(entities), metaData: entities.MetaData);
			
		}
	}
}
