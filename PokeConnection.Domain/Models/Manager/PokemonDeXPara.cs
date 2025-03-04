using PokeConnection.Domain.Entities;

namespace PokeConnection.Domain.Models.Manager;

public class PokemonDeXPara(Pokemon pokemon)
{
    public Pokemon Pokemon { get; private set; } = pokemon;
    public List<int>? EvolucoesId { get; private set; }
    public List<PokemonDeXPara>? Evolucoes { get; private set; } = [];

    public void AdicionarEvolucao(PokemonDeXPara evolucao)
    {
        Evolucoes?.Add(evolucao);
    }
}
