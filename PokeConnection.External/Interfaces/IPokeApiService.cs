﻿using PokeConnection.External.Responses;

namespace PokeConnection.External.Interfaces;
public interface IPokeApiService
{
    Task<PokemonResponse?> GetPokemonAsync(string pokemonName);
}
