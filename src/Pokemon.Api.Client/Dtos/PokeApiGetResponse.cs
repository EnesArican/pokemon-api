namespace Pokemon.Api.Client.Dtos;

using Json = System.Text.Json.Serialization.JsonPropertyNameAttribute;

public record PokeApiGetResponse
{
    [Json("flavor_text_entries")]
    public List<FlavorTextEntry> FlavourTextEntries { get; init; } = new List<FlavorTextEntry>();

    public Habitat? Habitat { get; init; }


    [Json("is_legendary")]
    public bool IsLegendary { get; init; } = false;
}


public record FlavorTextEntry
{ 
    [Json("flavor_text")]
    public string? FlavorText { get; init; }

    public Language? Language { get; init; }
}

public record Language 
{
    [Json("name")]
    public string? Code { get; init; }
}

public record Habitat
{ 
    public string? Name { get; init; }
}


