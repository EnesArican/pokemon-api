namespace Pokemon.Api.Client.Clients;

using System.Net.Http.Json;
using Pokemon.Api.Client.Dtos;

public class ShakespearClient : IShakespearClient
{
    private readonly HttpClient _httpClient;
    private const string RequestUri = "shakespear";

    public ShakespearClient(HttpClient httpClient) =>
        _httpClient = httpClient;

    public async Task<TranslationResponse> GetTranslationAsync(string text, CancellationToken token)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(RequestUri, new TranslationRequest(text), token)!;

        return await response.Content.ReadFromJsonAsync<TranslationResponse>(cancellationToken: token)
            ?? throw new InvalidOperationException("Unable to deserialize response content.");
    }
}

