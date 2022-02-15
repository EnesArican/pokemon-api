namespace Pokemon.Api.Interfaces;

using Pokemon.Api.Dtos;

public interface IInfoExtractor
{
    Task<PokemonInfo> GetBasicInfoAsync(string pokemonName, CancellationToken token);

    Task<PokemonInfo> GetTranslatedInfoAsync(string pokemonName, CancellationToken token);
}
