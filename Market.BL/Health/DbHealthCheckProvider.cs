using Market.Common.Constants;
using Market.DAL;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Market.Common.Health
{
    public class DbHealthCheckProvider : IHealthCheckProvider
    {
        public async Task<HealthCheckResult> GetHealthCheckAsync()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = new HealthCheckResult();
            result.HealthCheck.ResourceName = nameof(DbHealthCheckProvider);
            result.HealthCheck.Description = "Checks whether the database can be accessed.";
            result.HealthCheck.FriendlyName = "Checks the database";
            result.MachineName = Environment.MachineName;
            
            try
            {
                var context = new MarketDbContext();  
                var item = await context.Categories.FirstAsync(); 
                if (item != null)
                {
                    result.HealthCheck.State = HealthState.Healthy;
                    result.HealthCheck.Messages.Add(new Message {MessegeInfo= "Successfully retrieved a record from the database." });
                }
                else
                {
                    result.HealthCheck.State = HealthState.UnHealthy;
                    result.HealthCheck.Messages.Add(new Message { MessegeInfo = "Connected to the database but could not find the requested record." });
                    result.HasFailures = true;  
                }
            }
            catch
            {
                result.HealthCheck.State = HealthState.UnHealthy;
                result.HealthCheck.Messages.Add(new Message { MessegeInfo =  "Error retrieving a record from the database." });
                result.HasFailures = true;
            }
            stopwatch.Stop();
            result.TimeTakenInSeconds = stopwatch.Elapsed.TotalSeconds;
            return result;
        }
    }
}
