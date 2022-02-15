using Pokemon.Api.Client.Dtos;

namespace Pokemon.Api.Client.Clients
{
    public interface IShakespearClient
    {
        Task<TranslationResponse> GetTranslationAsync(string text, CancellationToken token);
    }
}