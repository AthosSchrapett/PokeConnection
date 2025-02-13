using Microsoft.Extensions.DependencyInjection;
using PokeConnection.Application.Services;
using PokeConnection.Domain.Interfaces;
using Polly;
using Polly.Extensions.Http;

namespace PokeConnection.API.Extensions;

public static class HttpClientExtension
{
    public static IServiceCollection AddHttpClientConfigurations(this IServiceCollection services)
    {
        services.AddHttpClient("PokeApi", client =>
        {
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        })
        .AddPolicyHandler(HttpPolicyExtensions.HandleTransientHttpError()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))))
        .AddPolicyHandler(HttpPolicyExtensions.HandleTransientHttpError()
            .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30)));

        services.AddScoped<IPokeApiService, PokeApiService>();

        return services;
    }
}
