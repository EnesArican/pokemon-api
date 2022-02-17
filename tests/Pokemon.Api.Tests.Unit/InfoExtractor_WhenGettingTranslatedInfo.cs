namespace Pokemon.Api.Tests.Unit;

using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;

public class InfoExtractor_WhenGettingTranslatedInfoAsync : InfoExtractor_Backend
{
    [Test]
    public async Task Should_call_poke_api_client()
    {
        Given.Valid_pokemon_name();
        Given.Valid_poke_api_client_response();
        await When.Getting_basic_info();
        Then.Should_call_poke_api_client_get_pokemon_info(); 
    }

    [TestCase("cave", false)]
    [TestCase("other", true)]
    public async Task Should_call_yoda_translator_client(string habitat, bool isLegendary)
    {
        Given.Valid_pokemon_name();
        Given.Valid_poke_api_client_response_with(habitat, isLegendary);
        await When.Getting_translated_info();
        Then.Should_call_yoda_client_get_translation();
    }

    [TestCase("Cave")]
    [TestCase("ccave")]
    [TestCase("CAVE")]
    public async Task Should_call_shakespear_translator_client(string habitat)
    {
        Given.Valid_pokemon_name();
        Given.Valid_poke_api_client_response_with(habitat);
        await When.Getting_translated_info();
        Then.Should_call_shakespear_client_get_translation();
    }

    [Test]
    public async Task Should_return_translated_description() 
    {
        var expectedDescription = "test";
        
        Given.Valid_pokemon_name();
        Given.Valid_poke_api_client_response();
        Given.Valid_shakespear_client_response_with(expectedDescription);
        await When.Getting_translated_info();
        Then.Data.Result.Description.Should().Be(expectedDescription);
    }

    [Test]
    public async Task Should_return_poke_api_description()
    {
        var expectedDescription = "test";

        Given.Valid_pokemon_name();
        Given.Valid_poke_api_client_response_with(description: expectedDescription);
        Given.Invalid_shakespear_client_response();
        await When.Getting_translated_info();
        Then.Data.Result.Description.Should().Be(expectedDescription);
    }
}