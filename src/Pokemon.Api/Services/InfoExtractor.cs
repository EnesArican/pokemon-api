namespace Pokemon.Api.Services;

using Pokemon.Api.Dtos;
using Pokemon.Api.Mappers;
using Pokemon.Api.Interfaces;
using Pokemon.Api.Client.Clients;
using Pokemon.Api.Client.Interfaces;

public class InfoExtractor : IInfoExtractor
{
    private const string CaveString = "Cave";
    private readonly IPokeApiClient _pokeApiClient;
    private readonly ILogger<InfoExtractor> _logger;
    private readonly IYodaTranslatorClient _yodaClient;
    private readonly IShakespearClient _shakespearClient;
    public InfoExtractor(IPokeApiClient pokeApiClient,
                         ILogger<InfoExtractor> logger,
                         IYodaTranslatorClient yodaClient,
                         IShakespearClient shakespearClient)
    {
        _logger = logger;
        _yodaClient = yodaClient;
        _pokeApiClient = pokeApiClient;
        _shakespearClient = shakespearClient;
    }

    public async Task<PokemonInfo> GetBasicInfoAsync(string pokemonName, CancellationToken token) 
    {
        var response = await _pokeApiClient.GetPokemonInfoAsync(pokemonName, token);

        return response.Map(pokemonName);
    }

    public async Task<PokemonInfo> GetTranslatedInfoAsync(string pokemonName, CancellationToken token) 
    {
        var basicInfo = await GetBasicInfoAsync(pokemonName, token);

        return basicInfo with { Description = await TryTranslateAsync(basicInfo, token) };
    }

    private async Task<string?> TryTranslateAsync(PokemonInfo pokemonInfo, CancellationToken token) 
    {
        string? description;

        try 
        {
            var response = pokemonInfo switch
            {
                { Habitat: CaveString } or { IsLegendary: true } => await _yodaClient.GetTranslationAsync(pokemonInfo.Description!, token),
                _                                                => await _shakespearClient.GetTranslationAsync(pokemonInfo.Description!, token)
            };

            description = response?.Contents?.Translated;
        }
        catch (Exception e) 
        {
            _logger.LogError(e, "Error when attempting to translate description");

            description = pokemonInfo.Description;
        }
        
        return description;
    }

}

