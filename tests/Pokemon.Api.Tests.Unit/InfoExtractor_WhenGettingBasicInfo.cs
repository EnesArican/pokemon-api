namespace Pokemon.Api.Tests.Unit;

using NUnit.Framework;
using System.Threading.Tasks;

public class InfoExtractor_WhenGettingBasicInfoAsync : InfoExtractor_Backend
{
    [Test]
    public async Task Should_call_poke_api_client()
    {
        Given.Valid_pokemon_name();
        Given.Valid_poke_api_client_response();
        await When.Getting_basic_info();
        Then.Should_call_poke_api_client_get_pokemon_info();
    }
}