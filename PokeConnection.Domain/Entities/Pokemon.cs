using PokeConnection.Domain.Entities.Base;

namespace PokeConnection.Domain.Entities;
public class Pokemon(
    string nome, 
    string primeiroTipo, 
    string? segundoTipo,
    Habilidade[] habilidades
) : BaseEntity
{
    public string Nome { get; private set; } = nome;
    public string PrimeiroTipo { get; private set; } = primeiroTipo;
    public string? SegundoTipo { get; private set; } = segundoTipo;
    public Habilidade[] Habilidades { get; private set; } = habilidades;
}
