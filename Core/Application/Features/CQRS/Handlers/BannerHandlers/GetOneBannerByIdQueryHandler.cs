using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForBanner;
using MediatR;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetOneBannerByIdQueryHandler : IRequestHandler<GetOneBannerByIdQuery, GetOneBannerByIdQueryResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetOneBannerByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<GetOneBannerByIdQueryResult> Handle(GetOneBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _repositoryManager.BannerRepository.GetByFilter(false, x => x.Id == request.Id).SingleOrDefault();
            if (result is null)
                throw new BannerNotFoundException(request.Id);
            return _mapper.Map<GetOneBannerByIdQueryResult>(result);

        }
    }
}
