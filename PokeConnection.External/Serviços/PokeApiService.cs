using PokeConnection.External.Interfaces;
using PokeConnection.External.Responses;
using System.Text.Json;

namespace PokeConnection.Application.Services;
public class PokeApiService(IHttpClientFactory httpClientFactory) : IPokeApiService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("PokeApi");

    public async Task<PokemonResponse?> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"pokemon/{pokemonName}");

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return JsonSerializer.Deserialize<PokemonResponse>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}
