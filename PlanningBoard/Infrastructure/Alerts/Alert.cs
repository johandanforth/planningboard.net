namespace PlanningBoard.Infrastructure.Alerts
{
    public class Alert
    {
        public Alert(string alertLevel, string message)
        {
            AlertClass = "alert-" + alertLevel;
            AlertLevel = alertLevel;
            Message = message;
        }

        public string AlertClass { get; set; }
        public string AlertLevel { get; set; }
        public string Message { get; set; }
    }
}