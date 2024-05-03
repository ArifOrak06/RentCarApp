using Application.Features.CQRS.Commands.FooterAddressCommands;
using Application.Features.CQRS.Results.FooterAdressResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.FooterAddressHandlers
{
	public class CreateOneFooterAddressCommandHandler : IRequestHandler<CreateOneFooterAddressCommand, CreateOneFooterAddressCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CreateOneFooterAddressCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<CreateOneFooterAddressCommandResult> Handle(CreateOneFooterAddressCommand request, CancellationToken cancellationToken)
		{
			var newFooter = _mapper.Map<FooterAddress>(request);
			newFooter.CreatedDate = DateTime.UtcNow;
			newFooter.ModifiedDate = DateTime.UtcNow;
			newFooter.IsActive = true;
			newFooter.IsDeleted = false;
			await _repositoryManager.FooterAddressRepository.CreateAsync(newFooter);
			await _unitOfWork.CommitAsync();
			return _mapper.Map<CreateOneFooterAddressCommandResult>(newFooter);
		}
	}
}
