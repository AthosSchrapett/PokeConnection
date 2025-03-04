using PokeConnection.Application.Services;
using PokeConnection.Domain.Interfaces.Services;

namespace PokeConnection.API.Extensions;

public static class ServicesExtension
{
    public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IPokemonService, PokemonService>();

        return services;
    }
}
