using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Volo.Abp;

namespace AbpTempSimpleApp.HealthChecks;

public static class HealthChecksBuilderExtensions
{
    public static void AddAbpTempSimpleAppHealthChecks(this IServiceCollection services)
    {
        // Add your health checks here
        var healthChecksBuilder = services.AddHealthChecks();
        healthChecksBuilder.AddCheck<AbpTempSimpleAppDatabaseCheck>("AbpTempSimpleApp DbContext Check", tags: new string[] { "database" });

        var configuration = services.GetConfiguration();
        var healthCheckPath = configuration["App:HealthCheckUrl"];

        if (string.IsNullOrWhiteSpace(healthCheckPath))
        {
            healthCheckPath = "/health-status";
        }

        services.ConfigureHealthCheckEndpoint("/health-status");

        var healthCheckUiUri = ResolveHealthChecksUiUri(configuration, healthCheckPath);

        var healthChecksUiBuilder = services.AddHealthChecksUI(settings =>
        {
            settings.AddHealthCheckEndpoint("AbpTempSimpleApp Health Status", healthCheckUiUri);
        });

        // Set your HealthCheck UI Storage here
        healthChecksUiBuilder.AddInMemoryStorage();

        services.MapHealthChecksUiEndpoints(options =>
        {
            options.UIPath = "/health-ui";
            options.ApiPath = "/health-api";
        });
    }

    private static IServiceCollection ConfigureHealthCheckEndpoint(this IServiceCollection services, string path)
    {
        services.Configure<AbpEndpointRouterOptions>(options =>
        {
            options.EndpointConfigureActions.Add(endpointContext =>
            {
                endpointContext.Endpoints.MapHealthChecks(
                    new PathString(path.EnsureStartsWith('/')),
                    new HealthCheckOptions
                    {
                        Predicate = _ => true,
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                        AllowCachingResponses = false,
                    });
            });
        });

        return services;
    }

    /// <summary>
    /// HealthChecks UI polls this URL in a background worker. Relative paths are resolved against
    /// <c>App:SelfUrl</c> so preview binds (0.0.0.0:8080) are not used as HTTP client targets.
    /// </summary>
    private static string ResolveHealthChecksUiUri(IConfiguration configuration, string healthCheckPath)
    {
        if (healthCheckPath.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
            || healthCheckPath.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            return healthCheckPath;
        }

        var selfUrl = configuration["App:SelfUrl"]?.TrimEnd('/');
        if (string.IsNullOrWhiteSpace(selfUrl))
        {
            return healthCheckPath.EnsureStartsWith('/');
        }

        return $"{selfUrl}{healthCheckPath.EnsureStartsWith('/')}";
    }

    private static IServiceCollection MapHealthChecksUiEndpoints(this IServiceCollection services, Action<global::HealthChecks.UI.Configuration.Options>? setupOption = null)
    {
        services.Configure<AbpEndpointRouterOptions>(routerOptions =>
        {
            routerOptions.EndpointConfigureActions.Add(endpointContext =>
            {
                endpointContext.Endpoints.MapHealthChecksUI(setupOption);
            });
        });

        return services;
    }
}
