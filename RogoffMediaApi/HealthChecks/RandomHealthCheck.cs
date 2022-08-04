using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace RogoffMediaApi.HealthChecks;

public class RandomHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        int responseTimeInMs = Random.Shared.Next(300);
        if (responseTimeInMs < 100)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy(
                    $"The response time is excellent ({responseTimeInMs})"
                    )
                );
        }
        else if (responseTimeInMs < 200)
        {
            return Task.FromResult(
                HealthCheckResult.Degraded(
                    $"The response time is greater than expected ({responseTimeInMs})"
                    )
                );
        }
        else
        {
            return Task.FromResult(
                HealthCheckResult.Unhealthy(
                    $"The response time is unacceptable ({responseTimeInMs})"
                    )
                );
        }
    }
}
