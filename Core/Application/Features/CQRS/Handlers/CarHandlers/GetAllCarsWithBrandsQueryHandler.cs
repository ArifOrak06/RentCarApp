using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetAllCarsWithBrandsQueryHandler : IRequestHandler<GetAllCarsWithBrandsQuery, (List<GetAllCarsWithBrandsQueryResult> result, MetaData metaData)>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetAllCarsWithBrandsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<(List<GetAllCarsWithBrandsQueryResult> result, MetaData metaData)> Handle(GetAllCarsWithBrandsQuery request, CancellationToken cancellationToken)
		{
			var entities = await _repositoryManager.CarRepository.GetAllCarsAsync(false, request, x => x.IsActive && !x.IsDeleted, x => x.CarDescriptions, x => x.Brand);
			if (entities.Any())
				throw new Exception("Database'de kayıtlı Car nesnesi bulunmamaktadır.");
			var newCarResultList = _mapper.Map<List<GetAllCarsWithBrandsQueryResult>>(entities);
			return (result: newCarResultList, metaData: entities.MetaData);
		}
	}
}
