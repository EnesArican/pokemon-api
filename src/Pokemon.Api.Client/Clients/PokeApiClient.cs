namespace Pokemon.Api.Client.Clients;

using System.Net.Http.Json;
using Pokemon.Api.Client.Dtos;
using Pokemon.Api.Client.Interfaces;

public class PokeApiClient : IPokeApiClient
{
    private readonly HttpClient _httpClient;

    public PokeApiClient(HttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task<PokeApiGetResponse> GetPokemonInfo(string name, CancellationToken token)
    {
        return await _httpClient.GetFromJsonAsync<PokeApiGetResponse>(name, token);


        
    }
}
