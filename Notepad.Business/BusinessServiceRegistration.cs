
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Notepad.Business.Mapper;
using Notepad.Business.Services.Implementations;
using Notepad.Business.Services.Interfaces;
using System.Reflection;

namespace Notepad.Business
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public static void AddDIServices(this IServiceCollection services) 
        {
            #region Services
            services.AddScoped<INoteService,NoteService>();
            #endregion
        }
    }
}
