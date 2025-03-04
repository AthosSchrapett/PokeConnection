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
            [.. pokemonResponse.types.Select(type => new Tipo(type.type.name))],
            [.. pokemonResponse.abilities.Select(ability => new Habilidade(ability.ability.name))]
        );
    }

    public static PokemonResponseDTO ConvertToDTO(this Pokemon pokemon)
    {
        return new PokemonResponseDTO
        (
            pokemon.Nome,
            pokemon.Tipos[0].Nome,
            pokemon.Tipos.Count > 1 ? pokemon.Tipos[1].Nome : null
        );
    }
}
