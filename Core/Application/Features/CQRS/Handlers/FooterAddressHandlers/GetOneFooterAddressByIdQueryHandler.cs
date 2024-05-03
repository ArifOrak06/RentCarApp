using Application.Features.CQRS.Queries.FooterAddressQueries;
using Application.Features.CQRS.Results.FooterAdressResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForFooterAddress;
using MediatR;

namespace Application.Features.CQRS.Handlers.FooterAddressHandlers
{
	public class GetOneFooterAddressByIdQueryHandler : IRequestHandler<GetOneFooterAddressByIdQuery, GetOneFooterAddressByIdQueryResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetOneFooterAddressByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<GetOneFooterAddressByIdQueryResult> Handle(GetOneFooterAddressByIdQuery request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.FooterAddressRepository.GetByFilter(false, x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentEntity == null)
				throw new FooterAddressNotFoundException(request.Id);
			return _mapper.Map<GetOneFooterAddressByIdQueryResult>(currentEntity);
		}
	}
}
