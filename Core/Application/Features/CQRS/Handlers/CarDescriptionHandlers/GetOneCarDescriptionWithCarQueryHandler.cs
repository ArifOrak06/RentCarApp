using Application.Features.CQRS.Queries.CarDescriptionQueries;
using Application.Features.CQRS.Results.CarDescriptionResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForCarDescription;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
	public class GetOneCarDescriptionWithCarQueryHandler : IRequestHandler<GetOneCarDescriptionWithCarByIdQuery, GetOneCarDescriptionWithCarByIdQueryResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetOneCarDescriptionWithCarQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<GetOneCarDescriptionWithCarByIdQueryResult> Handle(GetOneCarDescriptionWithCarByIdQuery request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.CarDescriptionRepository.GetByFilter(false, x => x.Id == request.Id, x => x.Car).SingleOrDefault();
			if (currentEntity == null)
				throw new CarDescriptionNotFoundException(request.Id);
			return _mapper.Map<GetOneCarDescriptionWithCarByIdQueryResult>(currentEntity);
		}
	}
}
