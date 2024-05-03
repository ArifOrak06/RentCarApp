using Application.Features.CQRS.Commands.ProvidedServicesCommands;
using Application.Features.CQRS.Queries.ProvidedServiceQueries;
using Domain.Exceptions.Concretes.ExceptionsForProvidedService;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCarAPI.ActionFilters;

namespace RentCarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProvidedServicesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProvidedServicesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProvidedServices()
		{
			var result = await _mediator.Send(new GetAllProvidedServicesQuery());
			return Ok(result);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneProvidedService([FromRoute(Name="id")]int id)
		{
			var result = await _mediator.Send(new GetOneProvidedServiceByIdQuery(id));
			return Ok(result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPost]
		public async Task<IActionResult> CreateOneProvidedService([FromBody]CreateOneProvidedServiceCommand command)
		{
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateOneProvidedService([FromRoute(Name="id")]int id, [FromBody]UpdateOneProvidedServiceCommand command)
		{
			if (id != command.Id)
				throw new ProvidedServiceParametersNotMatchedBadRequestException(id, command.Id);
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOneProvidedService([FromRoute(Name="id")]int id)
		{
			var result = await _mediator.Send(new HardRemoveOneProvidedServiceCommand(id));
			return StatusCode(200, result);
		}
	}
}
