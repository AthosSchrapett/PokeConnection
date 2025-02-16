using PokeConnection.Domain.Entities.Base;

namespace PokeConnection.Domain.Entities;

public class Habilidade(string? nome) : BaseEntity
{
    public string? Nome { get; private set; } = nome;
    public string? Efeito { get; private set; }
}
