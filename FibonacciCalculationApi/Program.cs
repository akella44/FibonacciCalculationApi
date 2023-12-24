using FibonacciCalculationApi.Math;
using FibonacciCalculationApi.RabbitMq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add service for manage connection to rabbitmq serv
builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();
// Add service for fibonacci seq calculation
// We're using singleton, cuz FibonacciCalcService class have inmemory cashe
builder.Services.AddSingleton<IFibonacciAsyncCalcService, FibonacciCalcService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
