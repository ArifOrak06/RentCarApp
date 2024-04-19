using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Results.CarResults;
using Application.Repositories;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Exceptions.Concretes.ExceptionsForCar;
using MediatR;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
	public class UpdateOneCarCommandHandler : IRequestHandler<UpdateOneCarCommand, UpdateOneCarCommandResult>
	{
		private readonly IRepositoryManager _repositoryManager;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateOneCarCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_repositoryManager = repositoryManager;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<UpdateOneCarCommandResult> Handle(UpdateOneCarCommand request, CancellationToken cancellationToken)
		{
			var unchangedEntity = _repositoryManager.CarRepository.GetByFilter(true, x => x.Id == request.Id).SingleOrDefault();
			if (unchangedEntity == null)
				throw new CarNotFoundException(request.Id);
			unchangedEntity.Transmission = request.Transmission;
			unchangedEntity.BigImageUrl = request.BigImageUrl;
			unchangedEntity.CoverImageUrl = request.CoverImageUrl;
			unchangedEntity.Kilometers = request.Kilometers;
			unchangedEntity.Fuel = request.Fuel;
			unchangedEntity.Luggage = request.Luggage;
			unchangedEntity.Model = request.Model;
			unchangedEntity.Seat = request.Seat;
			unchangedEntity.BrandId = request.BrandId;
			unchangedEntity.IsActive = request.IsActive;
			unchangedEntity.ModifiedDate = DateTime.UtcNow;
			if (request.IsActive) unchangedEntity.IsDeleted = false; else unchangedEntity.IsDeleted = true;
			await _unitOfWork.CommitAsync();
			return _mapper.Map<UpdateOneCarCommandResult>(unchangedEntity);
		}
	}
}
