using Application.Features.CQRS.Queries.PricingQueries;
using Application.Features.CQRS.Results.PricingResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForPricing;
using MediatR;

namespace Application.Features.CQRS.Handlers.PricingHandlers
{
	public class GetOnePricingByIdWithCarPricingsQueryHandler : IRequestHandler<GetOnePricingWithCarPricingsByIdQuery, GetOnePricingWithCarPricingsByIdQueryResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetOnePricingByIdWithCarPricingsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<GetOnePricingWithCarPricingsByIdQueryResult> Handle(GetOnePricingWithCarPricingsByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = _repositoryManager.PricingRepository.GetByFilter(false, x =>x.Id.Equals(request.Id)&&x.IsActive&&!x.IsDeleted,x => x.CarPricings).SingleOrDefault();
			if (entity == null)
				throw new PricingNotFoundException(request.Id);
			return _mapper.Map<GetOnePricingWithCarPricingsByIdQueryResult>(entity);
		}
	}
}
