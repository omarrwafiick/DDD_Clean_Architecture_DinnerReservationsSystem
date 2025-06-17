﻿using ApplicationLayer.DependencyInjection;
using PresentationLayer.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

var app = builder.Build();
 
try
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
catch (Exception ex)
{
    Console.WriteLine("swagger failed to start:");
    Console.WriteLine(ex.ToString());
}

app.UseHttpsRedirection();

//app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseExceptionHandler("/error");

//app.Map("/error", (HttpContext context) =>
//{ 
//    Exception? exception = context.Features.Get<IExceptionHandlerFeature>().Error;

//    var (statusCode, message) = exception switch
//    {
//        IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.Message),
//        _ => (StatusCodes.Status500InternalServerError, "Unexpected internal server error"),
//    };
//    return Results.Problem(statusCode: statusCode, title: message);
//});

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
 