using AutoMapper;
using BankingSystem;
using BankingSystem.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServiceDependecyHelper.RegisterServices(builder.Services);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
LoadData.LoadInMemoryData(app);

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
