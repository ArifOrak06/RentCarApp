using Application.Features.CQRS.Commands.CarCommands;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Queries.CarQueries;
using Domain.Entities.RequestFeatures;
using Domain.Exceptions.Concretes.ExceptionsForCar;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentCarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneCar([FromRoute(Name = "id")]int id)
		{
			var result = await _mediator.Send(new GetOneCarWithBrandByIdQuery(id));
			return StatusCode(200, result);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCars([FromQuery]CarRequestParameters carRequestParameters)
		{
			var result = await _mediator.Send(new GetAllCarsWithBrandsQuery(carRequestParameters.PageNumber, carRequestParameters.PageSize));
			// Sayfalama künye bilgileri Response-Headers'a eklenecek.
			return StatusCode(200, result.result);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOneCar([FromBody]CreateOneCarCommand command)
		{
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateOneCar([FromRoute(Name="id")]int id, [FromBody]UpdateOneCarCommand command)
		{
			if (id != command.Id)
				throw new CarParametersNotMatchedBadRequestException(command.Id, id);
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[HttpDelete("{id:int}")]  // HardRemoveOneCarCommandHandler yapısı inşa edilmedi edilecek.
		public async Task<IActionResult> DeleteOneCar([FromRoute(Name = "id")] int id)
		{
			var result = await _mediator.Send(new HardRemoveOneCarCommand(id));
			return StatusCode(200, result);
		}
	}
}
