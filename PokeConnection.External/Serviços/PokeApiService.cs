using PokeConnection.External.Interfaces;
using PokeConnection.External.Responses;
using System.Text.Json;

namespace PokeConnection.External.Serviços;
public class PokeApiService(IHttpClientFactory httpClientFactory) : IPokeApiService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("PokeApi");

    public async Task<PokemonResponse?> GetPokemonAsync(string pokemonName)
    {
        var content = await RetornaConsultaPokeAPI($"pokemon/{pokemonName}");

        if (content is null) return null;

        return JsonSerializer.Deserialize<PokemonResponse>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public async Task<PokemonSpeciesResponse?> GetPokemonSpeciesAsync(string pokemonName)
    {
        var content = await RetornaConsultaPokeAPI($"pokemon-species/{pokemonName}");

        if (content is null) return null;

        return JsonSerializer.Deserialize<PokemonSpeciesResponse>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    public async Task<EvolutionChainResponse?> GetEvolutionChainAsync(string idEvolutionChain)
    {
        var content = await RetornaConsultaPokeAPI($"evolution-chain/{idEvolutionChain}");

        if (content is null) return null;

        return JsonSerializer.Deserialize<EvolutionChainResponse>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }

    private async Task<string?> RetornaConsultaPokeAPI(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);

        var content = await response.Content.ReadAsStringAsync();
        
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return content;
    }
}
