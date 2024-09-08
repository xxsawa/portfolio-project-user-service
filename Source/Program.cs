using Microsoft.Azure.Cosmos;
using Source;
using Source.CosmosDbService;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var cosmosDbSettings = builder.Configuration.GetSection("CosmosDb");
var connectionString = cosmosDbSettings["ConnectionString"];
var databaseName = cosmosDbSettings["DatabaseName"];
var containerName = cosmosDbSettings["ContainerName"];

// Add services to the container.
builder.Services.AddSingleton<CosmosDbConnection>(options =>
{
    return new CosmosDbConnection(connectionString, databaseName, containerName);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
