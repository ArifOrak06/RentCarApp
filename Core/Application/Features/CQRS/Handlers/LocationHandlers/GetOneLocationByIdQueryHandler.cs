using Application.Features.CQRS.Queries.LocationQueries;
using Application.Features.CQRS.Results.LocationResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForLocation;
using MediatR;

namespace Application.Features.CQRS.Handlers.LocationHandlers
{
	public class GetOneLocationByIdQueryHandler : IRequestHandler<GetOneLocationByIdQuery, GetOneLocationByIdQueryResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetOneLocationByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<GetOneLocationByIdQueryResult> Handle(GetOneLocationByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = _repositoryManager.LocationRepository.GetByFilter(false,x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (entity == null)
				throw new LocationNotFoundException(request.Id);
			return _mapper.Map<GetOneLocationByIdQueryResult>(entity);
		
		}
	}
}
