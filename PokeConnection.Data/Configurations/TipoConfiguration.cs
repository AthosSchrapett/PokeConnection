using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeConnection.Domain.Entities;

namespace PokeConnection.Data.Configurations;

internal class TipoConfiguration : IEntityTypeConfiguration<Tipo>
{
    public void Configure(EntityTypeBuilder<Tipo> builder)
    {
        builder.ToTable("tb_tipo");

        builder.Property(p => p.Nome)
            .HasColumnName("nome")
            .HasColumnType("varchar(100)")
            .IsRequired();
    }
}
