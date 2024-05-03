using Application.Features.CQRS.Queries.ProvidedServiceQueries;
using Application.Features.CQRS.Results.ProvidedServiceResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.ProvidedServiceHandlers
{
	public class GetAllProvidedServicesQueryHandler : IRequestHandler<GetAllProvidedServicesQuery, List<GetAllProvidedServicesQueryResult>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetAllProvidedServicesQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<List<GetAllProvidedServicesQueryResult>> Handle(GetAllProvidedServicesQuery request, CancellationToken cancellationToken)
		{
			List<ProvidedService>? providedServices = await _repositoryManager.ProvidedServiceRepository.GetAllAsync(false, x => x.IsActive && !x.IsDeleted);
			if (!providedServices.Any())
				throw new Exception("Sistemde kayıtlı providedService varlığı bulunmamaktadır.");
			return _mapper.Map<List<GetAllProvidedServicesQueryResult>>(providedServices);
		}
	}
}
