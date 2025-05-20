
using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Notepad.WebAPI.HangfireSettings
{
    public class AllowAllUserDashboard : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
