using PokeConnection.Domain.DTOs.Pokemon.Response;
using PokeConnection.Domain.Interfaces;
using System.Text.Json;

namespace PokeConnection.Application.Services;
public class PokeApiService(IHttpClientFactory httpClientFactory) : IPokeApiService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("PokeApi");

    public async Task<PokemonResponseDTO?> GetPokemonAsync(string pokemonName)
    {
        var response = await _httpClient.GetAsync($"pokemon/{pokemonName}");

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<PokemonResponseDTO>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}
