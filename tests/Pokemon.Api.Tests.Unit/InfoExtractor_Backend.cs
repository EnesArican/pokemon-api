namespace Pokemon.Api.Tests.Unit;

using Moq;
using NUnit.Framework;
using Pokemon.Api.Dtos;
using Pokemon.Api.Interfaces;
using Pokemon.Api.Client.Dtos;
using Pokemon.Api.Client.Clients;
using Microsoft.Extensions.Logging;
using Pokemon.Api.Client.Interfaces;

public abstract class InfoExtractor_Backend
{
    protected Mock<IPokeApiClient> _mockPokeApiClient;
    protected Mock<IYodaTranslatorClient> _mockYodaClient;
    protected Mock<IShakespearClient> _mockShakespearClient;
    protected Mock<ILogger<Services.InfoExtractor>> _mockLogger;

    public DataContext Data;
    protected IInfoExtractor Cut;

    [SetUp]
    public void Setup()
    {
        _mockPokeApiClient = new Mock<IPokeApiClient>();
        _mockYodaClient = new Mock<IYodaTranslatorClient>();
        _mockShakespearClient = new Mock<IShakespearClient>();
        _mockLogger = new Mock<ILogger<Services.InfoExtractor>>();

        Data = new DataContext();

        Cut = new Services.InfoExtractor(_mockPokeApiClient.Object,
                                          _mockLogger.Object,
                                          _mockYodaClient.Object,
                                          _mockShakespearClient.Object);
    }


    protected InfoExtractor_Backend Given => this;
    protected InfoExtractor_Backend When => this;
    public InfoExtractor_Backend Then => this;


    //GIVEN//
    public void Valid_pokemon_name() =>
        Data.PokemonName = "TestName";

    public void Valid_poke_api_client_response() 
    {
        _mockPokeApiClient.Setup(x => x.GetPokemonInfoAsync(It.IsAny<string>(), default))
                          .ReturnsAsync(new PokeApiGetResponse());
    }

    public void Valid_poke_api_client_response_with(string habitat = null, bool isLegendary = false, string description = null) 
    { 
        _mockPokeApiClient.Setup(x => x.GetPokemonInfoAsync(It.IsAny<string>(), default))
                          .ReturnsAsync(new PokeApiGetResponse 
                          { 
                              IsLegendary = isLegendary,
                              Habitat = new Habitat { Name = habitat },
                              FlavourTextEntries = new List<FlavorTextEntry> 
                              {
                                  new FlavorTextEntry 
                                  {
                                      FlavorText = description,
                                      Language = new Language { Code = "en" }
                                  }
                              },
                          });
    }

    public void Valid_shakespear_client_response_with(string description)
    {
        _mockShakespearClient.Setup(x => x.GetTranslationAsync(It.IsAny<string>(), default))
                             .ReturnsAsync(new TranslationResponse 
                             { 
                                 Contents = new Content { Translated = description }
                             });
    }

    public void Invalid_shakespear_client_response()
    {
        _mockShakespearClient.Setup(x => x.GetTranslationAsync(It.IsAny<string>(), default))
                             .ThrowsAsync(new Exception());
    }


    //WHEN//
    public async Task Getting_basic_info() =>
        Data.Result = await Cut.GetBasicInfoAsync(Data.PokemonName, default);

    public async Task Getting_translated_info() =>
       Data.Result = await Cut.GetTranslatedInfoAsync(Data.PokemonName, default);



    //THEN//
    public void Should_call_poke_api_client_get_pokemon_info() 
    {
        _mockPokeApiClient.Verify(x => x.GetPokemonInfoAsync(Data.PokemonName, default), Times.Once);
    }

    public void Should_call_yoda_client_get_translation()
    {
        _mockYodaClient.Verify(x => x.GetTranslationAsync(It.IsAny<string>(), default), Times.Once);
    }

    public void Should_call_shakespear_client_get_translation()
    {
        _mockShakespearClient.Verify(x => x.GetTranslationAsync(It.IsAny<string>(), default), Times.Once);
    }


    //DATA//
    public class DataContext 
    { 
        public string PokemonName { get; set; }

        public PokemonInfo Result { get; set; }
    }
}