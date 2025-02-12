using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeConnection.Domain.Entities.Base;
public class BaseEntity
{
    public int Id { get; private set; }
    public DateOnly DataCriacao { get; private set; }
    public DateOnly DataAtualizacao { get; private set; }
    public bool Ativo { get; private set; }
}
