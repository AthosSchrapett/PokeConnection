using PokeConnection.Domain.Entities.Base;
using PokeConnection.Domain.Entities.Relational;

namespace PokeConnection.Domain.Entities;
public class Tipo(string nome) : BaseEntity
{
    public string Nome { get; private set; } = nome;
    public virtual ICollection<TipoRelacao> Fraquezas { get; private set; } = [];
    public virtual ICollection<TipoRelacao> Resistencias { get; private set; } = [];
}
