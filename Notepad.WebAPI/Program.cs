
using Notepad.Business;
using Notepad.Core.Settings;
using Notepad.DAL;
using Notepad.Infrastructure;
using Hangfire;
using Notepad.Infrastructure.BackgroundJobs;
using Notepad.WebAPI.HangfireSettings;

namespace Notepad.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            DALServiceRegistration.AddDIRepository(builder.Services);
            DALServiceRegistration.AddDAL(builder.Services, builder.Configuration);
            BusinessServiceRegistration.AddBusiness(builder.Services);
            BusinessServiceRegistration.AddDIServices(builder.Services);
            InfrastructureServiceRegistration.AddInfrastructure(builder.Services);
            builder.Services.Configure<Link>(builder.Configuration.GetSection("Link"));
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("AllowUI", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();

                });
            });
            builder.Services.AddHangfireServer();
            builder.Services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(builder.Configuration.GetConnectionString("prod"));
            });



            var app = builder.Build();
            app.UseCors("AllowUI");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseHangfireDashboard("/hangfire/notepad/secret", new DashboardOptions
            {
                Authorization = new[] { new AllowAllUserDashboard() }
            });
            app.UseAuthorization();
            app.MapControllers();
            RecurringJob.AddOrUpdate<NoteJobs>(
                "delete-old-notes",
                job => job.DeleteOldNotesJob(), Cron.Daily);
            app.Run();
        }
    }
}
