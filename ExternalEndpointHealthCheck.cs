using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace Microservice{
    public class ExternalEndpointHealthCheck : IHealthCheck
{

    private readonly ServiceSettings _settings;
    public ExternalEndpointHealthCheck(IOptions<ServiceSettings> options)
    {
        _settings = options.Value;
    }
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var ping = new Ping();
        var reply = await ping.SendPingAsync(_settings.OpenWeatherHost);

        if(reply.Status != IPStatus.Success)
            return HealthCheckResult.Unhealthy();

        return HealthCheckResult.Healthy();
    }
}
}