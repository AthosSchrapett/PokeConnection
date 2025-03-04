using PokeConnection.Domain.Interfaces.Repositories;

namespace PokeConnection.Domain.Interfaces.Persistence;

public interface IUnitOfWork
{
    public IPokemonRepository PokemonRepository { get; }
    public Task<bool> SaveChangesAsync();
}
