namespace Pokemon.Api.Controllers;

using Pokemon.Api.Dtos;
using Pokemon.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IInfoExtractor _infoExtractor;
    private readonly ILogger<PokemonController> _logger;

    public PokemonController(IInfoExtractor infoExtractor,
                             ILogger<PokemonController> logger)
    {
        _logger = logger;
        _infoExtractor = infoExtractor;
    }

    [HttpGet("{pokemonName}")]
    public Task<PokemonInfo> Get(string pokemonName, CancellationToken token = default)
    {
        return _infoExtractor.GetBasicInfoAsync(pokemonName, token);
    }

    [HttpGet("translated/{pokemonName}")]
    public Task<PokemonInfo> GetTranslated(string pokemonName, CancellationToken token = default)
    {
        return _infoExtractor.GetTranslatedInfoAsync(pokemonName, token);
    }
}
