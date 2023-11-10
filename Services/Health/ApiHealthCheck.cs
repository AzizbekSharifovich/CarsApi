using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestSharp;

namespace CarsApi.Services.Health;

public class ApiHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var url = "https://airport-info.p.rapidapi.com/airport?iata=BEY";

        var client = new RestClient();

        var request = new RestRequest(url, Method.Get);
        request.AddHeader(name:"X-RapidAPI-Key", value:"SIGN-UP-FOR-KEY");
        request.AddHeader(name:"X-RapidAPI-Host", value: "airport-info.p.rapidapi.com");

        var response = client.Execute(request);

        if(response.IsSuccessful)
            return Task.FromResult(HealthCheckResult.Healthy());
        else
            return Task.FromResult(HealthCheckResult.Unhealthy());
    }
}
