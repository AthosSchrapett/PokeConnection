using PokeConnection.Application.Adapter;
using PokeConnection.Domain.DTOs.Pokemon;
using PokeConnection.Domain.Entities;
using PokeConnection.Domain.Entities.Relational;
using PokeConnection.Domain.Exceptions;
using PokeConnection.Domain.Interfaces.Services;
using PokeConnection.Domain.Models.Manager;
using PokeConnection.External.Interfaces;
using PokeConnection.External.Responses;

namespace PokeConnection.Application.Services;

public class PokemonService : IPokemonService
{
    private readonly IPokeApiService _pokeApiService;

    public PokemonService(IPokeApiService pokeApiService)
    {
        _pokeApiService = pokeApiService;
    }

    public async Task<PokemonResponseDTO?> GetPokemonAsync(string pokemonName)
    {
        Pokemon pokemon = await BuscarEConverterPokemonAsync(pokemonName);

        await GerarEvolucoes(pokemon);

        return pokemon?.ConvertToDTO();
    }

    private async Task<Pokemon> BuscarEConverterPokemonAsync(string pokemonName)
    {
        var pokemonResponse = await _pokeApiService.GetPokemonAsync(pokemonName);

        return pokemonResponse?.ConvertToEntity() ?? throw new NaoEncontradoException();
    }

    private async Task GerarEvolucoes(Pokemon pokemon)
    {
        List<Evolucao> evolucoes = [];

        var pokemonSpeciesResponse = await _pokeApiService.GetPokemonSpeciesAsync(pokemon.Nome);

        var id = pokemonSpeciesResponse?.evolution_chain.url.TrimEnd('/').Split('/')[^1] ?? "";
        var evolutionChainResponse = await _pokeApiService.GetEvolutionChainAsync(id);

        if (evolutionChainResponse?.chain.evolves_to.Count > 0)
        {
            PokemonDeXPara? pokemonDeXPara = await ObterPokemonDeXPara(pokemon, evolutionChainResponse.chain.species.name);
            await BuscarEvolucoes(evolutionChainResponse.chain.evolves_to, pokemon, pokemonDeXPara);
        }
    }

    private async Task<PokemonDeXPara> ObterPokemonDeXPara(Pokemon pokemon, string nomePokemonAtual)
    {
        if (nomePokemonAtual != pokemon.Nome)
        {
            Pokemon pokemonBase = await BuscarEConverterPokemonAsync(nomePokemonAtual);
            return new(pokemonBase);
        }

        return new(pokemon);
    }

    private async Task BuscarEvolucoes(List<EvolvesToPokemon> evolvesTo, Pokemon pokemon, PokemonDeXPara pokemonDeXPara)
    {
        foreach (var evolution in evolvesTo)
        {
            PokemonDeXPara novaEvolucao = await ObterPokemonDeXPara(pokemon, evolution.species.name);
            pokemonDeXPara.AdicionarEvolucao(novaEvolucao);

            if (evolution.evolves_to.Count == 0)
                continue;

            await BuscarEvolucoes(evolution.evolves_to, pokemon, novaEvolucao);
        }
    }
}
