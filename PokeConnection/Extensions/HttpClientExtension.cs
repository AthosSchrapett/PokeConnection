using PokeConnection.Application.Services;
using PokeConnection.Domain.Interfaces;

namespace PokeConnection.API.Extensions;

public static class HttpClientExtension
{
    public static IServiceCollection AddHttpClientConfigurations(this IServiceCollection services)
    {
        services.AddHttpClient("PokeApi", client =>
        {
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        services.AddScoped<IPokeApiService, PokeApiService>();

        return services;
    }
}
