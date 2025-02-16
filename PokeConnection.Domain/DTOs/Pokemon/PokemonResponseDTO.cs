namespace PokeConnection.Domain.DTOs.Pokemon;

public record PokemonResponseDTO
(
    string Nome,
    string PrimeiroTipo,
    string? SegundoTipo
);
