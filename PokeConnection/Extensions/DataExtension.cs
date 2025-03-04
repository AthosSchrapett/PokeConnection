using Microsoft.EntityFrameworkCore;
using PokeConnection.Data.Persistence;

namespace PokeConnection.API.Extensions;

public static class DataExtension
{
    public static IServiceCollection AddDbConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PokemonContext>(opt =>
        {
            opt.UseNpgsql(configuration["ConnectionStrings:PokeDb"]);
        });
        return services;
    }
}
