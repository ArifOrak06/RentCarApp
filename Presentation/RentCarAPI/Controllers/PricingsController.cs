using Application.Features.CQRS.Handlers.PricingCommands;
using Application.Features.CQRS.Queries.PricingQueries;
using Domain.Entities.RequestFeatures;
using Domain.Exceptions.Concretes.ExceptionsForPricing;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCarAPI.ActionFilters;
using System.Text.Json;

namespace RentCarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PricingsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PricingsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllPricings([FromQuery] PricingRequestParameters pricingRequestParameters)
		{
			var result = await _mediator.Send(new GetAllPricingsWithCarPricingsQuery(pricingRequestParameters.PageNumber, pricingRequestParameters.PageSize));
			Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
			return Ok(result);

		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOnePricing([FromRoute(Name = "id")] int id)
		{
			var result = await _mediator.Send(new GetOnePricingWithCarPricingsByIdQuery(id));
			return Ok(result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPost]
		public async Task<IActionResult> CreateOnePricing([FromBody] CreateOnePricingCommand command)
		{
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateOnePricing([FromRoute(Name = "id")] int id, UpdateOnePricingCommand command)
		{
			if (id != command.Id)
				throw new PricingParametersNotMatchedBadRequestException(id, command.Id);
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOnePricing([FromRoute(Name = "id")] int id)
		{
			var result = await _mediator.Send(new HardRemoveOnePricingCommand(id));
			return StatusCode(200, result);
		}
	}
}
