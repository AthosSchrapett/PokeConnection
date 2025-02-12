using PokeConnection.Domain.DTOs.Pokemon.Response;

namespace PokeConnection.Domain.Interfaces;
public interface IPokeApiService
{
    Task<PokemonResponseDTO?> GetPokemonAsync(string pokemonName);
}
