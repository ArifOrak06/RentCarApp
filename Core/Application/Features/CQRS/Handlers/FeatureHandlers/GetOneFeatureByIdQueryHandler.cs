using Application.Features.CQRS.Queries.FeatureQueries;
using Application.Features.CQRS.Results.FeatureResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForFeature;
using MediatR;

namespace Application.Features.CQRS.Handlers.FeatureHandlers
{
	public class GetOneFeatureByIdQueryHandler : IRequestHandler<GetOneFeatureByIdQuery, GetOneFeatureByIdQueryResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetOneFeatureByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<GetOneFeatureByIdQueryResult> Handle(GetOneFeatureByIdQuery request, CancellationToken cancellationToken)
		{
			var entitiy = _repositoryManager.FeatureRepository.GetByFilter(false,x => x.Id == request.Id&&x.IsActive&&!x.IsDeleted,x =>x.CarFeatures);
			if (entitiy == null)
				throw new FeatureNotFoundException(request.Id);
			return _mapper.Map<GetOneFeatureByIdQueryResult>(entitiy);

		}
	}
}
