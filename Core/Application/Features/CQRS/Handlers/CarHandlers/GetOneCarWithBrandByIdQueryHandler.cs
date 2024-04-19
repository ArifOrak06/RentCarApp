using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForCar;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetOneCarWithBrandByIdQueryHandler : IRequestHandler<GetOneCarWithBrandByIdQuery, GetOneCarWithBrandByIdQueryResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetOneCarWithBrandByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<GetOneCarWithBrandByIdQueryResult> Handle(GetOneCarWithBrandByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = _repositoryManager.CarRepository.GetByFilter(false, x => x.Id.Equals(request.Id)&&x.IsActive && !x.IsDeleted, x => x.Brand, x => x.CarDescriptions).SingleOrDefault();
			if (entity == null)
				throw new CarNotFoundException(request.Id);
			return _mapper.Map<GetOneCarWithBrandByIdQueryResult>(entity);

		}
	}
}
