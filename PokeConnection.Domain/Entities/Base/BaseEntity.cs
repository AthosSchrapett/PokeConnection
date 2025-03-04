namespace PokeConnection.Domain.Entities.Base;
public abstract class BaseEntity
{
    public int Id { get; private set; }
    public DateOnly DataCriacao { get; private set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly DataAtualizacao { get; private set; } = DateOnly.FromDateTime(DateTime.Now);
    public bool Ativo { get; private set; }

    public virtual void Ativar()
    {
        Ativo = true;
        AtualizarData();
    }

    public virtual void Desativar()
    {
        Ativo = false;
        AtualizarData();
    }

    public void AtualizarData() => DataAtualizacao = DateOnly.FromDateTime(DateTime.Now);
}
