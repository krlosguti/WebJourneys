using Microsoft.OpenApi.Writers;
using WebJourneys.Application;
using WebJourneys.Infrastructure;
using WebJourneys.Infrastructure.Data;
using WebJourneys.Infrastructure.Data.Extentions;
using WebJourneys.Presentation;
using WebJourneys.Presentation.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();



app.RegisterMiddlewares();

app.Run();
