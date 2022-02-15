using Pokemon.Api.Client.Dtos;

namespace Pokemon.Api.Client.Clients
{
    public interface IYodaTranslatorClient
    {
        Task<TranslationResponse> GetTranslationAsync(string text, CancellationToken token);
    }
}