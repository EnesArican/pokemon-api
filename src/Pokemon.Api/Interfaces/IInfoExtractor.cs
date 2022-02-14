namespace Pokemon.Api.Interfaces;

using Pokemon.Api.Dtos;

public interface IInfoExtractor
{
    Task<BasicInfo> GetBasicInfoAsync(string pokemonName, CancellationToken token);
}
