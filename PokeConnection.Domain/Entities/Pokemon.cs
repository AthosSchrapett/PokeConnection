using PokeConnection.Domain.Entities.Base;
using PokeConnection.Domain.Entities.Relational;

namespace PokeConnection.Domain.Entities;
public class Pokemon(
    string nome,
    Tipo[] tipos,
    Habilidade[] habilidades
) : BaseEntity
{
    public string Nome { get; private set; } = nome;
    public virtual ICollection<Tipo> Tipos { get; private set; } = tipos;
    public virtual ICollection<Habilidade> Habilidades { get; private set; } = habilidades;
    public virtual Evolucao? EvoluiDe { get; private set; }
    public virtual ICollection<Evolucao>? EvoluiPara { get; private set; }
}
