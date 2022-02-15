namespace Pokemon.Api.Client.Dtos;

public record TranslationResponse
{
    public Content? Contents { get; init; }
}

public record Content 
{
    public string? Translated { get; init; }
}

