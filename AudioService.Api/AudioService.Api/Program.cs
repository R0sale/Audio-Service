using AudioService.Api.Middlewares;
using AudioService.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);
builder.Services.AddScoped<ExceptionHandlingMiddleware>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins(builder.Configuration["AllowedOrigin"]);
        policy.WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS");
    });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors("Frontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
