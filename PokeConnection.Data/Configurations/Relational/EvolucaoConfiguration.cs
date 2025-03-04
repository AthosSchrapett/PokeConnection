using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeConnection.Domain.Entities;
using System.Reflection.Emit;

namespace PokeConnection.Data.Configurations;

internal class EvolucaoConfiguration : IEntityTypeConfiguration<Evolucao>
{
    public void Configure(EntityTypeBuilder<Evolucao> builder)
    {
        builder.HasOne(e => e.PokemonBase)
            .WithMany(p => p.EvoluiPara)
            .HasForeignKey(e => e.PokemonBaseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.PokemonEvoluido)
            .WithOne(p => p.EvoluiDe)
            .HasForeignKey<Evolucao>(e => e.PokemonEvoluidoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
