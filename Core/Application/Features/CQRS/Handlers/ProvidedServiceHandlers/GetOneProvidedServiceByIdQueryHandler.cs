using Application.Features.CQRS.Queries.ProvidedServiceQueries;
using Application.Features.CQRS.Results.ProvidedServiceResults;
using Application.Repositories;
using AutoMapper;
using Domain.Entities.Concrete;
using Domain.Exceptions.Concretes.ExceptionsForProvidedService;
using MediatR;

namespace Application.Features.CQRS.Handlers.ProvidedServiceHandlers
{
	internal class GetOneProvidedServiceByIdQueryHandler : IRequestHandler<GetOneProvidedServiceByIdQuery, GetOneProvidedServiceByIdQueryResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetOneProvidedServiceByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<GetOneProvidedServiceByIdQueryResult> Handle(GetOneProvidedServiceByIdQuery request, CancellationToken cancellationToken)
		{
			ProvidedService? currentService = _repositoryManager.ProvidedServiceRepository.GetByFilter(false,x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentService == null) 
				throw new ProvidedServiceNotFoundException(request.Id);
			return _mapper.Map<GetOneProvidedServiceByIdQueryResult>(currentService);

		}
	}
}
