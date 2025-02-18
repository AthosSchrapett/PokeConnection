using Microsoft.AspNetCore.Mvc.Testing;
using PokeConnection.Domain.DTOs.Pokemon;
using System.Net;
using System.Net.Http.Json;

namespace PokeConnection.Tests;
public class PokeApiServiceTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;

    public PokeApiServiceTests(WebApplicationFactory<Program> factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Theory]
    [InlineData("pikachu", HttpStatusCode.OK, "pikachu", "electric", null)]
    [InlineData("unknown", HttpStatusCode.NotFound, null, null, null)]
    public async Task GetPokemonAsync_ValidaRespostas(
        string pokemonName, 
        HttpStatusCode expectedStatus,
        string? expectedName,
        string? expectedType1,
        string? expectedType2
    )
    {
        var response = await _httpClient.GetAsync($"/api/Pokemon?pokemonName={pokemonName}");
        Assert.Equal(expectedStatus, response.StatusCode);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<PokemonResponseDTO>();
            Assert.NotNull(result);
            Assert.Equal(expectedName, result.Nome);
            Assert.Equal(expectedType1, result.PrimeiroTipo);
            Assert.Equal(expectedType2, result.SegundoTipo);
        }
    }
}
