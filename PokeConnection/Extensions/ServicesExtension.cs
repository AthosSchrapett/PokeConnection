using PokeConnection.Application.Services;
using PokeConnection.Domain.Interfaces;

namespace PokeConnection.API.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IPokemonService, PokemonService>();

        return services;
    }
}
