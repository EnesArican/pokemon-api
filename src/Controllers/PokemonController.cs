namespace Pokemon.Api.Controllers;

using Pokemon.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Api.Interfaces;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly ILogger<PokemonController> _logger;
    private readonly IPokeApiClient _pokeApiClient;

    public PokemonController(IPokeApiClient pokeApiClient,
                             ILogger<PokemonController> logger)
    {
        _pokeApiClient = pokeApiClient;
        _logger = logger;
    }

    [HttpGet]
    public BasicInfo Get(string pokemonName)
    {

        return new();
    }
}
