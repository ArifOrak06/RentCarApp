using Application.Features.CQRS.Commands.FooterAddressCommands;
using Application.Features.CQRS.Queries.FooterAddressQueries;
using Domain.Exceptions.Concretes.ExceptionsForFooterAddress;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCarAPI.ActionFilters;

namespace RentCarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FooterAddressesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FooterAddressesController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllFooterAddresses()
		{
			var result = await _mediator.Send(new GetAllFooterAddressQuery());
			return Ok(result);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneFooterAddress([FromRoute(Name = "id")] int id)
		{
			var result = await _mediator.Send(new GetOneFooterAddressByIdQuery(id));
			return Ok(result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPost]
		public async Task<IActionResult> CreateOneFooterAddress([FromBody] CreateOneFooterAddressCommand command)
		{
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateOneFooterAddress([FromRoute(Name = "id")] int id, UpdateOneFooterAddressCommand command)
		{
			if (id != command.Id)
				throw new FooterAddressParametersNotMatchedBadRequestException(id, command.Id);
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOneFooterAddress([FromRoute(Name = "id")] int id)
		{
			var result = await _mediator.Send(new HardRemoveOneFooterAddressCommand(id));
			return StatusCode(200, result);
		}

	}
}
