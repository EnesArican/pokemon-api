namespace Pokemon.Api.Mappers;

using Pokemon.Api.Dtos;
using Pokemon.Api.Client.Dtos;

public static class PokeApiResponseMapper
{
    public static PokemonInfo Map(this PokeApiGetResponse response, string name) => new()
    {
        Name = name,
        Habitat = response.Habitat?.Name,
        IsLegendary = response.IsLegendary,
        Description = response.FlavourTextEntries.FirstOrDefault(x => x.Language?.Code?.Equals("en") ?? false)?.FlavorText,
    };
}

