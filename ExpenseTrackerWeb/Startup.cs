#region
using ExpenseTrackerWeb;
using Microsoft.Owin;
using Owin;
#endregion

[assembly: OwinStartup(typeof(Startup))]

namespace ExpenseTrackerWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}