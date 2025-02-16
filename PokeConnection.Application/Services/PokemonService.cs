using PokeConnection.Application.Adapter;
using PokeConnection.Domain.DTOs.Pokemon;
using PokeConnection.Domain.Interfaces;
using PokeConnection.External.Interfaces;

namespace PokeConnection.Application.Services;

public class PokemonService : IPokemonService
{
    private readonly IPokeApiService _pokeApiService;

    public PokemonService(IPokeApiService pokeApiService)
    {
        _pokeApiService = pokeApiService;
    }

    public async Task<PokemonResponseDTO?> GetPokemonAsync(string pokemonName)
    {
        var pokemonResponse = await _pokeApiService.GetPokemonAsync(pokemonName);
        var pokemon = pokemonResponse?.ConvertToEntity();

        return pokemon?.ConvertToDTO();
    }
}
