using System.Threading.Tasks;

namespace Market.Common.Health
{
    public interface IHealthCheckProvider
    {
        Task<HealthCheckResult> GetHealthCheckAsync();
    }
}
