namespace Pokemon.Api.Services;

using Pokemon.Api.Dtos;
using Pokemon.Api.Mappers;
using Pokemon.Api.Interfaces;
using Pokemon.Api.Client.Interfaces;

public class InfoExtractor : IInfoExtractor
{
    private readonly IPokeApiClient _pokeApiClient;
    public InfoExtractor(IPokeApiClient pokeApiClient) =>
        _pokeApiClient = pokeApiClient;

    public async Task<BasicInfo> GetBasicInfoAsync(string pokemonName, CancellationToken token) 
    {
        var response = await _pokeApiClient.GetPokemonInfo(pokemonName, token);

        return response.Map(pokemonName);
    }
}

