using RentCarAPI.Extensions.Mictosoft;
using Persistence.Extensions;
using NLog;
using Application.Services.Logging;
using RentCarAPI.Extensions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlServer(builder.Configuration);


// persistence layer
builder.Services.ConfigureRegistrationRepository();
builder.Services.ConfigureRegistrationServiceOfPersistence();


LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Api Controller'ýn auto Validasyon kontrolünü devre dýþý býrakalým
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
	options.SuppressModelStateInvalidFilter = true;
});
builder.Services.ConfigureCors();

// presentation Layer services to Registration
builder.Services.ConfigureNlog();
builder.Services.ConfigureServiceOfPresentation();
builder.Services.ConfigureAutoMapper();
builder.Services.RegistrationOfMediaTR();




var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.ConfigureExceptionHandler(logger);
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
