using Application.Features.CQRS.Commands.CarDescriptionCommands;
using Application.Features.CQRS.Queries.CarDescriptionQueries;
using Domain.Exceptions.Concretes.ExceptionsForCarDescription;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCarAPI.ActionFilters;

namespace RentCarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDescriptionsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarDescriptionsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCarDescriptions()
		{
			var result = await _mediator.Send(new GetAllCarDescriptionsWithCarsQuery());
			return Ok(result);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneCarDescription([FromRoute(Name ="id")]int id)
		{
			var result = await _mediator.Send(new GetOneCarDescriptionWithCarByIdQuery(id));
			return Ok(result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPost]
		public async Task<IActionResult> CreateOneCarDescription([FromBody]CreateOneCarDescriptionCommand command)
		{
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateOneCarDescription([FromRoute(Name="id")]int id, [FromBody]UpdateOneCarDescriptionCommand command)
		{
			if (id != command.Id)
				throw new CarDescriptionParametersNotMatchedBadRequestException(id, command.Id);
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOneCarDescription([FromRoute(Name="id")]int id)
		{
			var result = await _mediator.Send(new HardRemoveOneCarDescriptionCommand(id));
			return StatusCode(201, result);
		}
	}
}
