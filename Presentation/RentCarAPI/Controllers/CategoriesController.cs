using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Queries.CategoryQueries;
using Domain.Entities.RequestFeatures;
using Domain.Exceptions.Concretes.ExceptionForCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCarAPI.ActionFilters;
using System.Text.Json;

namespace RentCarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CategoriesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCAtegories([FromQuery]CategoryRequestParameters categoryRequestParameters)
		{
			var result = await _mediator.Send(new GetAllCategoriesQuery(categoryRequestParameters.PageNumber, categoryRequestParameters.PageSize));
			Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(result.metaData));
			return Ok(result.result);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneCategory([FromRoute(Name="id")]int id)
		{
			var result = await _mediator.Send(new GetOneCategoryByIdQuery(id));
			return StatusCode(200, result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPost]
		public async Task<IActionResult> CreateOneCategory([FromBody]CreateOneCategoryCommand command)
		{
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateOneCategory([FromRoute(Name="id")]int id, [FromBody]UpdateOneCategoryCommand command)
		{
			if (id != command.Id)
				throw new CategoryParamatersNotMatchedBadRequestException(id, command.Id);
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOneCategory([FromRoute(Name="id")]int id)
		{
			var result = await _mediator.Send(new HardRemoveOneCategoryCommand(id));
			return StatusCode(201,result);
		}
	}
}
