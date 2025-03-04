using PokeConnection.Domain.DTOs.Pokemon;

namespace PokeConnection.Domain.Interfaces.Services;

public interface IPokemonService
{
    Task<PokemonResponseDTO?> GetPokemonAsync(string pokemonName);
}
