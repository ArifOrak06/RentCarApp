using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
	public class GetAllBrandsWithCarsQueryHandler : IRequestHandler<GetAllBrandsWithCarsQuery, (List<GetAllBrandsWithCarsQueryResult> result, MetaData metaData)>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetAllBrandsWithCarsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<(List<GetAllBrandsWithCarsQueryResult> result, MetaData metaData)> Handle(GetAllBrandsWithCarsQuery request, CancellationToken cancellationToken)
		{
			var entities = await _repositoryManager.BrandRepository.GetAllBrandsAsync(false, request, x => x.IsActive && !x.IsDeleted, x => x.Cars);
			return (result: _mapper.Map<List<GetAllBrandsWithCarsQueryResult>>(entities), metaData: entities.MetaData);
		}
	}
}
