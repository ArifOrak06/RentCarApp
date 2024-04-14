using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetAllBannersQueryHandler : IRequestHandler<GetAllBannersQuery, IEnumerable<GetAllBannersQueryResult>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GetAllBannersQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllBannersQueryResult>> Handle(GetAllBannersQuery request, CancellationToken cancellationToken)
        {
            var results = await _repositoryManager.BannerRepository.GetAllAsync(false);
            if (results == null)
                throw new Exception("Sistemde kayıtlı banner varlığı bulunmamaktadır.");
            return _mapper.Map<IEnumerable<GetAllBannersQueryResult>>(results);
        }
    }
}
