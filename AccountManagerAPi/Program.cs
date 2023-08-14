using DataAccessLayer;
using ApplicationLayer;
using System.Text.Json.Serialization;
using Mapster;
using AccountManagerAPi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(builder => builder.AddConsole());
builder.Services.RegisterDalServices(builder.Configuration);
builder.Services.AddServiceLayer();
TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);
TypeAdapterConfig.GlobalSettings.Scan(typeof(Program).Assembly);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Startup
{

}