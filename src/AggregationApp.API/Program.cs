using AggregationApp.Application;
using AggregationApp.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

CsvImport.ImportCsvAsync(app.Configuration, "https://data.gov.lt/dataset/1975/download/10743/2020-06.csv", true).Wait();
CsvImport.ImportCsvAsync(app.Configuration, "https://data.gov.lt/dataset/1975/download/10744/2020-07.csv", false).Wait();

app.Run();
