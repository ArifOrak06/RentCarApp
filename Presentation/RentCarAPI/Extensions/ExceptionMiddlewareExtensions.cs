using Application.Services.Logging;
using Domain.ErrorModels;
using Domain.Exceptions.Abstracts;
using Microsoft.AspNetCore.Diagnostics;

namespace RentCarAPI.Extensions
{
	public static class ExceptionMiddlewareExtensions
	{
		public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					context.Response.ContentType = "application/json";
					var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); // hataları seçtik.
					if(contextFeature != null)
					{
						//hata varsa status code atamasını hatanın status code'una göre kendi abstract custom hatamızı dönmemiz gerekmektedir.
						context.Response.StatusCode = contextFeature.Error switch
						{
							NotFoundException => StatusCodes.Status404NotFound,
							BadRequestException => StatusCodes.Status400BadRequest,
							_ => StatusCodes.Status500InternalServerError
						};
						logger.LogError($"Something went wrong : {contextFeature.Error}");

						//client'a dönülecek olan response'a kendi hata modelimiz olan ErrorDetails'i ekleyelim ve onu dönelim.
						await context.Response.WriteAsync(new ErrorDetails
						{
							StatusCode = context.Response.StatusCode,
							ErrorMessage = contextFeature.Error.Message
						}.ToString());
					}
				});
			});
		}
	}
}
