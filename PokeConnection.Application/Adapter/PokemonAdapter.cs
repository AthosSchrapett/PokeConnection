using PokeConnection.Domain.DTOs.Pokemon;
using PokeConnection.Domain.Entities;
using PokeConnection.External.Responses;

namespace PokeConnection.Application.Adapter;

public static class PokemonAdapter
{
    public static Pokemon ConvertToEntity(this PokemonResponse pokemonResponse)
    {
        return new Pokemon
        (
            pokemonResponse.name,
            pokemonResponse.types[0].type.name,
            pokemonResponse.types.Count > 1 ? pokemonResponse.types[1].type.name : null,
            [.. pokemonResponse.abilities.Select(ability => new Habilidade(ability.ability.name))]
        );
    }

    public static PokemonResponseDTO ConvertToDTO(this Pokemon pokemon)
    {
        return new PokemonResponseDTO
        (
            pokemon.Nome,
            pokemon.PrimeiroTipo,
            pokemon.SegundoTipo
        );
    }
}
