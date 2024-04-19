using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
	public class CreateOneCarCommandHandler : IRequestHandler<CreateOneCarCommand, CreateOneCarCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateOneCarCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_repositoryManager = repositoryManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<CreateOneCarCommandResult> Handle(CreateOneCarCommand request, CancellationToken cancellationToken)
		{
			var newCar = _mapper.Map<Car>(request);
			newCar.CreatedDate = DateTime.UtcNow;
			newCar.IsActive = true;
			newCar.IsDeleted = false;
			newCar.ModifiedDate = DateTime.UtcNow;
			await _repositoryManager.CarRepository.CreateAsync(newCar);
			await _unitOfWork.CommitAsync();
			return _mapper.Map<CreateOneCarCommandResult>(newCar);
		}
	}
}
