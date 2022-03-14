using Market.Common.Health;
using System.Threading.Tasks;
using System.Web.Http;

namespace Market.API.Controllers
{
    public class HealthController : ApiController
    {
        private readonly IHealthCheckProvider _healthCheckProvider;

        public HealthController(IHealthCheckProvider healthCheckProvider)
        {
            _healthCheckProvider = healthCheckProvider;
        }
        [HttpGet]
        [Route("Health/CheckHealth")]
        public async Task<IHttpActionResult> CheckHealth()
        {
            HealthCheckResult result = await _healthCheckProvider.GetHealthCheckAsync();
            return Ok(result);
        }
    }
}

