using PokeConnection.Application.Services;
using PokeConnection.External.Interfaces;
using Polly;
using Polly.Extensions.Http;
using System.Net;

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
            .OrResult(response => response.StatusCode == HttpStatusCode.RequestTimeout)
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromMilliseconds(500),
            (result, timeSpan, retryCount, context) =>
            {
                if (result.Result?.StatusCode == HttpStatusCode.NotFound)
                {
                    return;
                }
                Console.WriteLine($"Tentativa {retryCount} falhou. Tentando novamente em {timeSpan.TotalSeconds} segundos...");
            }))
        .AddPolicyHandler(HttpPolicyExtensions.HandleTransientHttpError()
            .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30)));

        services.AddTransient<IPokeApiService, PokeApiService>();

        return services;
    }
}
