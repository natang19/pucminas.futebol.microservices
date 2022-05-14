using MediatR;
using Microsoft.AspNetCore.OData;
using pucminas.futebol.microservices.core;
using pucminas.futebol.microservices.core.ModelOptions;
using pucminas.futebol.time.api._2_Infrastructure;
using pucminas.futebol.time.api._2_Infrastructure.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MongoDbConnection>(builder.Configuration.GetSection("MongoDbConnection"));
builder.Services.AddSingleton<ITimeRepositorio, TimeRepositorio>();
builder.Services.AddMediatR(typeof(MediatrEntryPoint));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();
