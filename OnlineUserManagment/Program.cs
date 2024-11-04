using FastEndpoints;
using FastEndpoints.Swagger;
using OnlineUserManagment.Domain.Contracts;
using OnlineUserManagment.Infrastructure.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(builder.Configuration["Redis:ConnectionString"]));
builder.Services.AddSingleton<ILiteDBService, LiteDBService>();
builder.Services.AddSingleton<IUserTrackingService, UserTrackingService>();
builder.Services.AddFastEndpoints().SwaggerDocument();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        origin => origin.WithOrigins(builder.Configuration["Origin:OriginLink"]) // Allow specific origin
                          .AllowAnyHeader() // Allow any header
                          .AllowAnyMethod()); // Allow any method
});

var app = builder.Build();
app.UseCors("AllowSpecificOrigin");
app.UseFastEndpoints().UseSwaggerGen();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
