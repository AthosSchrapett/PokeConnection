using Microsoft.EntityFrameworkCore;
using PokeConnection.Domain.Entities;
using PokeConnection.Domain.Entities.Relational;

namespace PokeConnection.Data.Persistence;

public class PokemonContext(DbContextOptions<PokemonContext> options) : DbContext(options)
{
    DbSet<Pokemon> Pokemons { get; set; }
    DbSet<Evolucao> Evolucoes { get; set; }
    DbSet<Tipo> Tipos { get; set; }
    DbSet<TipoRelacao> TiposRelacao { get; set; }
    DbSet<Habilidade> Habilidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PokemonContext).Assembly);
    }
}
