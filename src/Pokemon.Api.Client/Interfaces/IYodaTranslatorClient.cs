namespace Pokemon.Api.Client.Clients;

using Pokemon.Api.Client.Dtos;

public interface IYodaTranslatorClient
{
    Task<TranslationResponse> GetTranslationAsync(string? text, CancellationToken token);
}