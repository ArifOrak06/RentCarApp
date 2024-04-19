using Application.Features.CQRS.Queries.BrandQueries;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionForBrand;
using MediatR;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
	public class GetOneBrandWithCarsQueryHandler : IRequestHandler<GetOneBrandWithCarsQuery, GetOneBrandWithCarsQueryResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetOneBrandWithCarsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<GetOneBrandWithCarsQueryResult> Handle(GetOneBrandWithCarsQuery request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.BrandRepository.GetByFilter(false, x => x.Id.Equals(request.Id) && x.IsActive && !x.IsDeleted, x => x.Cars).SingleOrDefault();
			if (currentEntity == null)
				throw new BrandNotFoundException(request.Id);
			return _mapper.Map<GetOneBrandWithCarsQueryResult>(currentEntity);
		}
	}
}
