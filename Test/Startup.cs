using System.Collections.Generic;
using Hangfire;
using Hangfire.Dashboard;
using Microsoft.Owin;
using Owin;
using Test.Models;

[assembly: OwinStartupAttribute(typeof(Test.Startup))]
namespace Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configuration
                .UseSqlServerStorage(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-Test-20181029110102;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    Authorization = new[] {new DashboardAuthorizationFilter()}
            //});
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
