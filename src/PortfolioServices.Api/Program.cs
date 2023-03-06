using PortfolioServices.Api.Infracstructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
await app.AddConfigureAsync();