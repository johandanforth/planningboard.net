using Microsoft.Owin;
using Owin;
using PlanningBoard;

[assembly: OwinStartup(typeof(Startup))]

namespace PlanningBoard
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
