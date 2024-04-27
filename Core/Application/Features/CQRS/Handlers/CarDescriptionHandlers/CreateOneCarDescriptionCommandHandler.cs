using Application.Features.CQRS.Commands.CarDescriptionCommands;
using Application.Features.CQRS.Results.CarDescriptionResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
	public class CreateOneCarDescriptionCommandHandler : IRequestHandler<CreateOneCarDescriptionCommand, CreateOneCarDescriptionCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateOneCarDescriptionCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<CreateOneCarDescriptionCommandResult> Handle(CreateOneCarDescriptionCommand request, CancellationToken cancellationToken)
		{
			var newCarDescription = _mapper.Map<CarDescription>(request);
			newCarDescription.Description = request.Description;
			newCarDescription.CarId = request.CarId;
			newCarDescription.IsActive = true;
			newCarDescription.IsDeleted = false;
			newCarDescription.ModifiedDate = DateTime.UtcNow;
			newCarDescription.CreatedDate = DateTime.UtcNow;
			await _repositoryManager.CarDescriptionRepository.CreateAsync(newCarDescription);
			await _unitOfWork.CommitAsync();
			return _mapper.Map<CreateOneCarDescriptionCommandResult>(newCarDescription);
		}
	}
}
