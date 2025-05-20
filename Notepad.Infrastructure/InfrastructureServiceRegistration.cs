
using Microsoft.Extensions.DependencyInjection;
using Notepad.Infrastructure.BackgroundJobs;

namespace Notepad.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<NoteJobs>();
        }
    }
}
