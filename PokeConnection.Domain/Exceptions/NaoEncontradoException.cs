namespace PokeConnection.Domain.Exceptions;

public class NaoEncontradoException : Exception
{
    public override string Message => "Registro não encontrado";
}
