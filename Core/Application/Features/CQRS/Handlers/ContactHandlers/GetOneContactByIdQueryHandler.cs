using Application.Features.CQRS.Queries.ContactQueries;
using Application.Features.CQRS.Results.ContactResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForContact;
using MediatR;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
	public class GetOneContactByIdQueryHandler : IRequestHandler<GetOneContactByIdQuery, GetOneContactByIdQueryResult>
	{
		private readonly IRepositoryManager _repositoryManger;
		private readonly IMapper _mapper;

		public GetOneContactByIdQueryHandler(IRepositoryManager repositoryManger, IMapper mapper)
		{
			_repositoryManger = repositoryManger;
			_mapper = mapper;
		}

		public async Task<GetOneContactByIdQueryResult> Handle(GetOneContactByIdQuery request, CancellationToken cancellationToken)
		{
			var currentEntitiy = _repositoryManger.ContactRepository.GetByFilter(false,x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentEntitiy == null)
				throw new ContactNotFoundException(request.Id);
			return _mapper.Map<GetOneContactByIdQueryResult>(currentEntitiy);

		}
	}
}
