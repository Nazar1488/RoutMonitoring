using Hangfire.Dashboard;
using Microsoft.Owin;

namespace Test.Models
{
    public class DashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var owinContext = new OwinContext(context.GetOwinEnvironment());
            return owinContext.Authentication.User.IsInRole("Admin");
        }
    }
}