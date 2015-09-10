using System.Web.Mvc;

namespace PlanningBoard.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ViewBag.Controller = System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        }
    }
}