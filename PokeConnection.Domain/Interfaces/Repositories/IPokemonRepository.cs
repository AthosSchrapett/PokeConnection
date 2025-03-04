using PokeConnection.Domain.Entities;

namespace PokeConnection.Domain.Interfaces.Repositories
{
    public interface IPokemonRepository
    {
        public Pokemon GetPokemonById(int id);
        public IEnumerable<Pokemon> GetAllPokemons();
        public Task AddPokemonAsync(Pokemon pokemon);
    }
}
