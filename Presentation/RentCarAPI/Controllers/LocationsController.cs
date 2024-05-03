using Application.Features.CQRS.Commands.LocationCommands;
using Application.Features.CQRS.Queries.LocationQueries;
using Domain.Exceptions.Concretes.ExceptionsForLocation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCarAPI.ActionFilters;

namespace RentCarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocationsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LocationsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllLocations()
		{
			var result = await _mediator.Send(new GetAllLocationsQuery());
			return Ok(result);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneLocation([FromRoute(Name="id")]int id)
		{
			var result = await _mediator.Send(id);
			return Ok(result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPost]
		public async Task<IActionResult> CreateOneLocation([FromBody]CreateOneLocationCommand command)
		{
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[ServiceFilter(typeof (ValidationFilterAttribute))]
		[HttpPut("{id:int")]
		public async Task<IActionResult> UpdateOneLocation([FromRoute(Name="id")]int id, [FromBody]UpdateOneLocationCommand command)
		{
			if (id != command.Id)
				throw new LocationParametersNotMatchedBadRequestException(id, command.Id);
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[HttpDelete("{id:int")]
		public async Task<IActionResult> DeleteOneLocation([FromRoute(Name="id")]int id)
		{
			var result = await _mediator.Send(new HardRemoveOneLocationCommand(id));
			return StatusCode(200,result);
		}
	}
}
