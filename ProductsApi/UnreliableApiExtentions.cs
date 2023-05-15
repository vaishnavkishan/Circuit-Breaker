using Polly;
using Polly.Extensions.Http;

namespace ProductsApi;

public static class UnreliableApiExtentions
{
    public static void AddUnreliableApi(this IServiceCollection services)
    {
        services.AddSingleton<IUnreliableApiClient, UnreliableApiClient>();

        var circuitBreakerPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(3, TimeSpan.FromSeconds(10));

        services.AddHttpClient<IUnreliableApiClient, UnreliableApiClient>(
                x => x.BaseAddress = new Uri("http://localhost:5076/"))
            .AddPolicyHandler(circuitBreakerPolicy);
    }
}