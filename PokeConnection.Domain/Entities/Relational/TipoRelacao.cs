using PokeConnection.Domain.Entities.Base;
using PokeConnection.Domain.Enums;

namespace PokeConnection.Domain.Entities.Relational;

public class TipoRelacao(int tipoId, int tipoAfetadoId, EnumTipoDefinicao tipoDefinicao) : BaseEntity
{
    public int TipoId { get; private set; } = tipoId;
    public virtual Tipo Tipo { get; private set; } = null!;
    public int TipoAfetadoId { get; private set; } = tipoAfetadoId;
    public virtual Tipo TipoAfetado { get; private set; } = null!;

    public EnumTipoDefinicao TipoDefinicao { get; private set; } = tipoDefinicao;
}
