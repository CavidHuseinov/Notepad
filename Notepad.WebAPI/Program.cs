
using Notepad.Business;
using Notepad.Core.Settings;
using Notepad.DAL;

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



            var app = builder.Build();
            app.UseCors("AllowUI");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
