using Application.Features.CQRS.Queries.LocationQueries;
using Application.Features.CQRS.Results.LocationResults;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CQRS.Handlers.LocationHandlers
{
	public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, List<GetAllLocationsQueryResult>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetAllLocationsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<List<GetAllLocationsQueryResult>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
		{
			var entities = await _repositoryManager.LocationRepository.GetAllAsync(false, x => x.IsActive && !x.IsDeleted);
			if (!entities.Any())
				throw new Exception("Sistemde kayıtlı Location nesnesi bulunmamaktadır.");
			return _mapper.Map<List<GetAllLocationsQueryResult>>(entities);

		}
	}
}
