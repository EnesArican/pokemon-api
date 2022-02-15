namespace Pokemon.Api.Client.Interfaces;

using Pokemon.Api.Client.Dtos;

public interface IPokeApiClient
{
    Task<PokeApiGetResponse> GetPokemonInfoAsync(string name, CancellationToken token);
}

