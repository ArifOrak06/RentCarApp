using Application.Features.CQRS.Commands.ContactCommands;
using Application.Features.CQRS.Queries.ContactQueries;
using Domain.Exceptions.Concretes.ExceptionsForContact;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCarAPI.ActionFilters;

namespace RentCarAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ContactsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllContacts()
		{
			var result = await _mediator.Send(new GetAllContactsQuery());
			return Ok(result);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneContact([FromRoute(Name = "id")] int id)
		{
			var result = await _mediator.Send(new GetOneContactByIdQuery(id));
			return Ok(result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPost]
		public async Task<IActionResult> CreateOneContact([FromBody] CreateOneContactCommand command)
		{
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPut]
		public async Task<IActionResult> UpdateOneContact([FromRoute(Name = "id")] int id, [FromBody] UpdateOneContactCommand command)
		{
			if (id != command.Id)
				throw new ContactParametersNotMatchedBadRequestException(id, command.Id);
			var result = await _mediator.Send(command);
			return StatusCode(201, result);
		}
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOneContact([FromRoute(Name = "id")] int id)
		{
			var result = await _mediator.Send(new HardRemoveOneContactCommand(id));
			return StatusCode(204);
		}
	}
}
