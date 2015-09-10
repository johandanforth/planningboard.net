using System.Web.Mvc;

namespace PlanningBoard.Infrastructure.Alerts
{
    public class AlertDecoratorResult : ActionResult
    {
        public AlertDecoratorResult(ActionResult innerResult, string alertLevel, string message)
        {
            InnerResult = innerResult;
            AlertLevel = alertLevel;
            Message = message;
        }

        public ActionResult InnerResult { get; set; }
        public string AlertLevel { get; set; }
        public string Message { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var alerts = context.Controller.TempData.GetAlerts();
            alerts.Add(new Alert(AlertLevel, Message));
            InnerResult.ExecuteResult(context);
        }
    }
}