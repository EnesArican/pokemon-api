namespace Pokemon.Api.Dtos;

public record ClientConfig
{
    public string PokeApiUrl { get; init; } = default!;
    public string TranslatorUrl { get; init; } = default!;
}

