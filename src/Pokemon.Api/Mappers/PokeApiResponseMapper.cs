using Pokemon.Api.Client.Dtos;
using Pokemon.Api.Dtos;

namespace Pokemon.Api.Mappers
{
    public static class PokeApiResponseMapper
    {
        private const string languageCode = "en";
        public static PokemonInfo Map(this PokeApiGetResponse response, string name) => new()
        {
            Name = name,
            Habitat = response.Habitat?.Name,
            IsLegendary = response.IsLegendary,
            Description = response.FlavourTextEntries.FirstOrDefault(x => x.Language?.Code?.Equals(languageCode) ?? false)?.FlavorText,
        };
    }
}
