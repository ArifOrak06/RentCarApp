using Application.Features.CQRS.Queries.ContactQueries;
using Application.Features.CQRS.Results.ContactResults;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
	public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<GetAllContactsQueryResult>>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;

		public GetAllContactsQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
		}

		public async Task<List<GetAllContactsQueryResult>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
		{
			var entities = _repositoryManager.ContactRepository.GetAllAsync(false, x => x.IsActive && !x.IsDeleted);
			if (entities is null)
				throw new Exception("Sistemde kayıtlı Contact nesnesi bulunmamaktadır.");
			return _mapper.Map<List<GetAllContactsQueryResult>>(entities);
			
		}
	}
}
