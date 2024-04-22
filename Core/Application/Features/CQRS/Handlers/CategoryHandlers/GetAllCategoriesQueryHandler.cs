using Application.Features.CQRS.Queries.CategoryQueries;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.RequestFeatures;
using MediatR;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, (List<GetAllCategoriesQueryResult> result, MetaData metaData)>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetAllCategoriesQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<(List<GetAllCategoriesQueryResult> result, MetaData metaData)> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
		{
			var entities = await _repositoryManager.CategoryRepository.GetAllCategoriesAsync(false, request, x => x.IsActive && !x.IsDeleted);
			return (result: _mapper.Map<List<GetAllCategoriesQueryResult>>(entities), metaData: entities.MetaData);
		}
	}
}
