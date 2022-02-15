using Pokemon.Api.Dtos;
using Pokemon.Api.Services;
using Pokemon.Api.Interfaces;
using Pokemon.Api.Client.Clients;
using Pokemon.Api.Client.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddSwaggerGen();
services.AddControllers();
services.AddEndpointsApiExplorer();

var cfg = builder.Configuration.GetSection(nameof(ClientConfig)).Get<ClientConfig>();

services.AddSingleton<IInfoExtractor, InfoExtractor>();
services.AddHttpClient<IPokeApiClient, PokeApiClient>(cl => cl.BaseAddress = new Uri(cfg.PokeApiUrl));
services.AddHttpClient<IShakespearClient, ShakespearClient>(cl => cl.BaseAddress = new Uri(cfg.TranslatorUrl));
services.AddHttpClient<IYodaTranslatorClient, YodaTranslatorClient>(cl => cl.BaseAddress = new Uri(cfg.TranslatorUrl));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
