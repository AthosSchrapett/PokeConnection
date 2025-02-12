using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeConnection.Domain.Interfaces;

namespace PokeConnection.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PokemonController : ControllerBase
{
    private readonly IPokeApiService _pokeApiService;

    public PokemonController(IPokeApiService pokeApiService)
    {
        _pokeApiService = pokeApiService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPokemonAsync(string pokemonName)
    {
        var pokemon = await _pokeApiService.GetPokemonAsync(pokemonName);
        
        if (pokemon is null)
        {
            return NotFound();
        }

        return Ok(pokemon);
    }
}
