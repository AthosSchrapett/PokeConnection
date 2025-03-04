using PokeConnection.Domain.Entities.Base;

namespace PokeConnection.Domain.Entities.Relational;

public class Evolucao(int pokemonBaseId, int pokemonEvoluidoId) : BaseEntity
{
    public int PokemonBaseId { get; private set; } = pokemonBaseId;
    public virtual Pokemon PokemonBase { get; private set; } = null!;
    public int PokemonEvoluidoId { get; private set; } = pokemonEvoluidoId;
    public virtual Pokemon PokemonEvoluido { get; private set; } = null!;
}
