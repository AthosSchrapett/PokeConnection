using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeConnection.Domain.Entities.Relational;

namespace PokeConnection.Data.Configurations.Relational
{
    internal class TipoRelacaoConfiguration : IEntityTypeConfiguration<TipoRelacao>
    {
        public void Configure(EntityTypeBuilder<TipoRelacao> builder)
        {
            builder.
                HasOne(tr => tr.Tipo).
                WithMany(t => t.Fraquezas).
                HasForeignKey(tr => tr.TipoId).
                OnDelete(DeleteBehavior.Restrict);

            builder.
                HasOne(tr => tr.TipoAfetado).
                WithMany(t => t.Resistencias).
                HasForeignKey(tr => tr.TipoAfetadoId).
                OnDelete(DeleteBehavior.Restrict);

            builder.Property(tr => tr.TipoDefinicao).HasConversion<int>();
        }
    }
}
