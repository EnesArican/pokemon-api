using Pokemon.Api.Dtos;
using Pokemon.Api.Services;
using Pokemon.Api.Interfaces;
using Pokemon.Api.Client.Clients;
using Pokemon.Api.Client.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.

services.AddSwaggerGen();
services.AddControllers();
services.AddEndpointsApiExplorer();

var cfg = builder.Configuration.GetSection(nameof(ClientConfig)).Get<ClientConfig>();

services.AddSingleton<IInfoExtractor, InfoExtractor>();
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
