using Application.Features.CQRS.Commands.SocialMediaCommands;
using Application.Features.CQRS.Queries.SocialMedaQueries;
using Domain.Exceptions.Concretes.ExceptionsForSocialMedia;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCarAPI.ActionFilters;

namespace RentCarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediasController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SocialMediasController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllSocialMedias()
		{
			var result = await _mediator.Send(new GetAllSocialMediasQuery());
			return Ok(result);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneSocialMedia([FromRoute(Name = "id")] int id)
		{
			var result = await _mediator.Send(new GetOneSocialMediaByIdQuery(id));
			return Ok(result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPost]
		public async Task<IActionResult> CreateOneSocialMedia([FromBody] CreateOneSocialMediaCommand command)
		{
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateOneSocialMedia([FromRoute(Name = "id")] int id, [FromBody] UpdateOneSocialMediaCommand command)
		{
			if (id != command.Id)
				throw new SocialMediaParametersNotMatchedBadRequestException(id, command.Id);
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOneSocialMedia([FromRoute(Name = "id")] int id)
		{
			var result = await _mediator.Send(new HardRemoveOneSocialMediaCommand(id));
			return Ok(result);
		}

	}
}
