using Application.Features.CQRS.Commands.FeatureCommands;
using Application.Features.CQRS.Queries.FeatureQueries;
using Domain.Exceptions.Concretes.ExceptionsForFeature;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCarAPI.ActionFilters;

namespace RentCarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FeaturesController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllFeatures()
		{
			var result = await _mediator.Send(new GetAllFeaturesQuery());
			return Ok(result);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneFeature(int id)
		{
			var result = await _mediator.Send(new GetOneFeatureByIdQuery(id));
			return Ok(result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPost]
		public async Task<IActionResult> CreateOneFeature([FromBody]CreateOneFeatureCommand command)
		{
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateOneFeature([FromRoute(Name="id")]int id, [FromBody]UpdateOneFeatureCommand command)
		{
			if(id != command.Id)
				throw new FeatureParametersNotMatchedBadRequestException(id, command.Id);
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOneFeature([FromRoute(Name="id")]int id)
		{
			var result = await _mediator.Send(new HardRemoveOneFeatureCommand(id));
			return StatusCode(201,result);
		}

		
	}
}
