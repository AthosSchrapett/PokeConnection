using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeConnection.Domain.Entities;

namespace PokeConnection.Data.Configurations;

internal class HabilidadeConfiguration : IEntityTypeConfiguration<Habilidade>
{
    public void Configure(EntityTypeBuilder<Habilidade> builder)
    {
        builder.ToTable("tb_habilidade");

        builder.Property(p => p.Nome)
            .HasColumnName("nome")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(p => p.Efeito)
            .HasColumnName("efeito")
            .HasColumnType("varchar(500)")
            .IsRequired();
    }
}
