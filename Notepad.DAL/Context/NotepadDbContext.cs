
using Microsoft.EntityFrameworkCore;
using Notepad.Core.Entities;
using System.Reflection;

namespace Notepad.DAL.Context
{
    public sealed class NotepadDbContext : DbContext
    {
        public NotepadDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
