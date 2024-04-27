using Application.Features.CQRS.Commands.ContactCommands;
using Application.Features.CQRS.Results.ContactResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForContact;
using MediatR;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
	public class UpdateOneContactCommandHandler : IRequestHandler<UpdateOneContactCommand, UpdateOneContactCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateOneContactCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<UpdateOneContactCommandResult> Handle(UpdateOneContactCommand request, CancellationToken cancellationToken)
		{
			var currentEntity = _repositoryManager.ContactRepository.GetByFilter(true,x => x.Id.Equals(request.Id)).SingleOrDefault();
			if(currentEntity == null)
				throw new ContactNotFoundException(request.Id);
			currentEntity.Subject = request.Subject;
			currentEntity.IsActive = request.IsActive;
			currentEntity.Name = request.Name;
			currentEntity.Email = request.Email;
			currentEntity.Message = request.Message;
			currentEntity.ModifiedDate = DateTime.UtcNow;
			if (request.IsActive) currentEntity.IsDeleted = false; else currentEntity.IsDeleted = true;
			await _unitOfWork.CommitAsync();
			return _mapper.Map<UpdateOneContactCommandResult>(currentEntity);
		}
	}
}
