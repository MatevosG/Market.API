using System.Collections.Generic;

namespace Market.Common.Health
{
    public class Message
    {
        public string MessegeInfo { get; set; }
    }

    public class HealthCheck
    {
        public HealthCheck()
        {
            Messages = new List<Message>(); 
        }
        public string ResourceName { get; set; }
        public string FriendlyName { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public List<Message> Messages { get; set; }
    }

    public class HealthCheckResult
    {
        public HealthCheckResult()
        {
            HealthCheck = new HealthCheck();
        }
        public bool HasFailures { get; set; }
        public string MachineName { get; set; }
        public double TimeTakenInSeconds { get; set; }
        public HealthCheck HealthCheck { get; set; }
    }
}
