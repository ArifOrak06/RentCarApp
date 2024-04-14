using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateOneBannerCommandHandler : IRequestHandler<CreateOneBannerCommand, CreateOneBannerCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOneBannerCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOneBannerCommandResult> Handle(CreateOneBannerCommand request, CancellationToken cancellationToken)
        {
            // Object Null kontrolü Presentation'da API controller içerisinde Action Filter marifetiyle yapılacaktır.

            var newBanner = _mapper.Map<Banner>(request);
            newBanner.CreatedDate = DateTime.UtcNow;
            newBanner.ModifiedDate = DateTime.UtcNow;
            newBanner.IsActive = true;
            newBanner.IsDeleted = false;

            await _repositoryManager.BannerRepository.CreateAsync(newBanner);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneBannerCommandResult>(newBanner);

        }
    }
}
