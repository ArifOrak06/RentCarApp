using Application.Features.CQRS.Queries.FooterAddressQueries;
using Application.Features.CQRS.Results.FooterAdressResults;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CQRS.Handlers.FooterAddressHandlers
{
	public class GetAllFooterAddressesQueryHandler : IRequestHandler<GetAllFooterAddressQuery, List<GetAllFooterAddressQueryResult>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetAllFooterAddressesQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<List<GetAllFooterAddressQueryResult>> Handle(GetAllFooterAddressQuery request, CancellationToken cancellationToken)
		{
			var entities = await _repositoryManager.FooterAddressRepository.GetAllAsync(false, x => x.IsActive &&!x.IsDeleted);
			if (!entities.Any())
				throw new Exception("Sistemde kayıtlı FooterAddress varlığı bulunmamaktadır.");
			return _mapper.Map<List<GetAllFooterAddressQueryResult>>(entities);
			
		}
	}
}
