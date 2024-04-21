using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Queries.BrandQueries;
using Domain.Entities.RequestFeatures;
using Domain.Exceptions.Concretes.ExceptionForBrand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCarAPI.ActionFilters;
using System.Text.Json;

namespace RentCarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BrandsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllActivesBrands([FromQuery]BrandRequestParameters brandRequestParameters)
		{
			var result = await _mediator.Send(new GetAllBrandsWithCarsQuery(brandRequestParameters.PageNumber, brandRequestParameters.PageSize));

			Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
			return Ok(result.result);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneActivesBrand([FromRoute(Name = "id")]int id)
		{
			var result = await _mediator.Send(new GetOneBrandWithCarsQuery(id));
			return StatusCode(200, result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPost]
		public async Task<IActionResult> CreateOneBrand([FromBody]CreateOneBrandCommand command)
		{
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateOneBrand([FromRoute(Name = "id")]int id, [FromBody]UpdateOneBrandCommand command)
		{
			if (id != command.Id)
				throw new BrandParametersNotMatchedBadRequestException(id, command.Id);
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOneBrand([FromRoute(Name="id")]int id)
		{
			var result = await _mediator.Send(new HardRemoveOneBrandCommand(id));
			return StatusCode(200, result);
		}

	}
}
