namespace Pokemon.Api.Client.Clients;

using Pokemon.Api.Client.Dtos;

public interface IShakespearClient
{
    Task<TranslationResponse> GetTranslationAsync(string? text, CancellationToken token);
}
