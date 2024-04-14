using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RentCarAPI.ActionFilters
{
	public class ValidationFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			// öncelikle controller ve ilgili method/action'ı seçelim.
			var currentController = context.RouteData.Values["controller"].ToString();
			var currentAction = context.RouteData.Values["action"];
			var param = context.ActionArguments.SingleOrDefault(p => p.Value.ToString().Contains("Command")).Value;
			if(param is null)
			{
				context.Result = new BadRequestObjectResult($"Object is null. " + $"Controller : {currentController}Controller " + $"Action : {currentAction} ");
				return; // statusCode 400 BadRequest
			}
			if (!context.ModelState.IsValid)
				context.Result = new UnprocessableEntityObjectResult(context.ModelState); // statusCode 422 Desteklenmeyen içerik.


		}
	}
}
