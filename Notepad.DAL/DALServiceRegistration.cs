
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notepad.DAL.Context;
using Notepad.DAL.Repositories.Implementations;
using Notepad.DAL.Repositories.Implementations.Generics;
using Notepad.DAL.Repositories.Interfaces;
using Notepad.DAL.Repositories.Interfaces.Generics;
using Notepad.DAL.UnitOfWorks;

namespace Notepad.DAL
{
    public static class DALServiceRegistration
    {
        public static void AddDAL(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<NotepadDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("env"));
            });
        }
        public static void AddDIRepository(this IServiceCollection services)
        {
            #region Generics
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            #endregion

            #region UnitOfWorks
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Repositories
            services.AddScoped<INoteRepo, NoteRepo>();
            #endregion  
        }
    }
}
