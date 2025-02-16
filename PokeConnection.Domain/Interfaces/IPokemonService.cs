using PokeConnection.Domain.DTOs.Pokemon;
using PokeConnection.Domain.Entities;

namespace PokeConnection.Domain.Interfaces
{
    public interface IPokemonService
    {
        Task<PokemonResponseDTO?> GetPokemonAsync(string pokemonName);
    }
}
