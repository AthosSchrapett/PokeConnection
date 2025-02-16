using Moq;
using Moq.Protected;
using System.Net;

namespace PokeConnection.Tests;
public class PokeApiServiceTests
{
    [Fact]
    public async Task GetPokemonAsync_RetornaPokemon_RespostaDaApiEhSucesso()
    {
        var jsonPath = Path.Combine(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..")), "TestsJSON", "pikachu.json");
        var json = File.ReadAllText(jsonPath);

        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json)
            });

        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://pokeapi.co/api/v2/")
        };

        httpClientFactoryMock.Setup(_ => _.CreateClient("PokeApi")).Returns(httpClient);
        var service = new PokeApiService(httpClientFactoryMock.Object);

        PokemonResponseDTO? pokemon = await service.GetPokemonAsync("pikachu");

        Assert.NotNull(pokemon);
        Assert.Equal("pikachu", pokemon.name);
        Assert.Equal(4, pokemon.height);
        Assert.Equal(60, pokemon.weight);
        //...
    }

    [Fact]
    public async Task GetPokemonAsync_RetornaNulo_QuandoApiFalha()
    {
        var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        handlerMock
           .Protected()
           .Setup<Task<HttpResponseMessage>>(
               "SendAsync",
               ItExpr.IsAny<HttpRequestMessage>(),
               ItExpr.IsAny<CancellationToken>()
           )
           .ReturnsAsync(new HttpResponseMessage
           {
               StatusCode = HttpStatusCode.NotFound
           });

        var httpClientFactoryMock = new Mock<IHttpClientFactory>();
        var httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("https://pokeapi.co/api/v2/")
        };

        httpClientFactoryMock.Setup(_ => _.CreateClient("PokeApi")).Returns(httpClient);
        var service = new PokeApiService(httpClientFactoryMock.Object);

        var pokemon = await service.GetPokemonAsync("unknown");

        Assert.Null(pokemon);
    }
}
