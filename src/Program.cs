using Pokemon.Api.Clients;
using Pokemon.Api.Dtos;
using Pokemon.Api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.

services.AddSwaggerGen();
services.AddControllers();
services.AddEndpointsApiExplorer();

var cfg = builder.Configuration.GetSection(nameof(ClientConfig)).Get<ClientConfig>();

services.AddHttpClient<IPokeApiClient, PokeApiClient>(cl => cl.BaseAddress = new Uri(cfg.PokeApiUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
