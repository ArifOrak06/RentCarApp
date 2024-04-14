using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Queries.BannerQueries;
using Domain.Exceptions.Concretes.ExceptionsForBanner;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCarAPI.ActionFilters;

namespace RentCarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BannersController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllBanners()
		{

			var result = await _mediator.Send(new GetAllBannersQuery());
			return Ok(result);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneBanner([FromRoute(Name ="id")]int id)
		{
			var result = await _mediator.Send(new GetOneBannerByIdQuery(id));
			return StatusCode(200,result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPost]
		public async Task<IActionResult> CreateOneBanner([FromBody]CreateOneBannerCommand createOneBannerCommand)
		{
			var result = await _mediator.Send(createOneBannerCommand);
			return StatusCode(201, result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateOneBanner([FromRoute(Name="id")]int id, UpdateOneBannerCommand command)
		{
			if (command.Id != id)
				throw new BannerParametersNotMatchedBadRequestException(command.Id, id);
			var result = await _mediator.Send(command);
			return StatusCode(201, result);

		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> HardRemoveOneBanner([FromRoute(Name="id")]int id)
		{
			var result = await _mediator.Send(new HardRemoveOneBannerCommand(id));
			return StatusCode(201, result);
		}
	}
}
