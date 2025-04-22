using ApplicationLayer.DependencyInjection;
 
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

builder.Services.AddControllers();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build(); 

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

app.Run();
