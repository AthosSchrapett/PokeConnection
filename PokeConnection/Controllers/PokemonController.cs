using Microsoft.AspNetCore.Mvc;
using PokeConnection.Domain.Interfaces.Services;

namespace PokeConnection.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PokemonController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPokemonAsync(string pokemonName)
    {
        var pokemon = await _pokemonService.GetPokemonAsync(pokemonName);
        return Ok(pokemon);
    }
}
