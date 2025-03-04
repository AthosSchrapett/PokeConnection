using PokeConnection.Domain.Interfaces.Persistence;
using PokeConnection.Domain.Interfaces.Repositories;

namespace PokeConnection.Data.Persistence;

public class UnitOfWork : IUnitOfWork
{
    public IPokemonRepository PokemonRepository => throw new NotImplementedException();

    public Task<bool> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
