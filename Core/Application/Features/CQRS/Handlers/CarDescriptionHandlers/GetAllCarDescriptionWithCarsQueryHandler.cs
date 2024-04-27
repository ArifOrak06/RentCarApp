using Application.Features.CQRS.Queries.CarDescriptionQueries;
using Application.Features.CQRS.Results.CarDescriptionResults;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
	public class GetAllCarDescriptionWithCarsQueryHandler : IRequestHandler<GetAllCarDescriptionsWithCarsQuery, List<GetAllCarDescriptionsWithCarsQueryResult>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetAllCarDescriptionWithCarsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<List<GetAllCarDescriptionsWithCarsQueryResult>> Handle(GetAllCarDescriptionsWithCarsQuery request, CancellationToken cancellationToken)
		{
			var entities = _repositoryManager.CarDescriptionRepository.GetByFilter(false, x => x.IsActive && !x.IsDeleted, x => x.Car);
			if (!entities.Any())
				throw new Exception("Sistemde kayıtlı CarDescription varlığı bulunmamaktadır.");
			return _mapper.Map<List<GetAllCarDescriptionsWithCarsQueryResult>>(entities);
		}
	}
}
