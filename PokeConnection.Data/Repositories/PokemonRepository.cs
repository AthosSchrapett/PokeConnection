using PokeConnection.Data.Persistence;
using PokeConnection.Domain.Entities;
using PokeConnection.Domain.Interfaces.Repositories;

namespace PokeConnection.Data.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private readonly PokemonContext _context;

    public PokemonRepository(PokemonContext context)
    {
        _context = context;
    }

    public Task AddPokemonAsync(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Pokemon> GetAllPokemons()
    {
        throw new NotImplementedException();
    }

    public Pokemon GetPokemonById(int id)
    {
        throw new NotImplementedException();
    }
}
