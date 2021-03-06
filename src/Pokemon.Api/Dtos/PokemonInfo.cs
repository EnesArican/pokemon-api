namespace Pokemon.Api.Dtos;

public record PokemonInfo
{
    public string Name { get; init; } = default!;
    public string? Description { get; init; } 
    public string? Habitat { get; init; } 
    public bool IsLegendary { get; init; }
}