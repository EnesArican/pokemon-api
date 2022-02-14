namespace Pokemon.Api.Clients;

using Pokemon.Api.Interfaces;

public class PokeApiClient : IPokeApiClient
{
    private readonly HttpClient _httpClient;
    public PokeApiClient(HttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task GetPokemonInfo(string name, CancellationToken token) 
    {
        var response = await _httpClient.GetAsync(name, token);


    }
}
