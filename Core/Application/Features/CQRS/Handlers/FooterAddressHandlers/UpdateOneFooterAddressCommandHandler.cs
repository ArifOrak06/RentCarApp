using Application.Features.CQRS.Commands.FooterAddressCommands;
using Application.Features.CQRS.Results.FooterAdressResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForFooterAddress;
using MediatR;

namespace Application.Features.CQRS.Handlers.FooterAddressHandlers
{
	public class UpdateOneFooterAddressCommandHandler : IRequestHandler<UpdateOneFooterAddressCommand, UpdateOneFooterAddressCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateOneFooterAddressCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<UpdateOneFooterAddressCommandResult> Handle(UpdateOneFooterAddressCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.FooterAddressRepository.GetByFilter(true, x => x.Id.Equals(request.Id)).SingleOrDefault();
			if (currentEntity == null)
				throw new FooterAddressNotFoundException(request.Id);
			currentEntity.PhoneNumber = request.PhoneNumber;
			currentEntity.Address = request.Address;
			currentEntity.Description = request.Description;
			currentEntity.Email = request.Email;
			currentEntity.ModifiedDate = DateTime.UtcNow;
			currentEntity.IsActive = request.IsActive;
			if (request.IsActive) currentEntity.IsDeleted = false; else currentEntity.IsDeleted = true;
			await _unitOfWork.CommitAsync();
			return _mapper.Map<UpdateOneFooterAddressCommandResult>(currentEntity);
		}
	}
}
