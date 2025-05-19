
using Microsoft.EntityFrameworkCore;
using Notepad.Core.Abstractions;
using Notepad.DAL.Context;
using Notepad.DAL.Repositories.Interfaces.Generics;

namespace Notepad.DAL.Repositories.Implementations.Generics
{
    public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly NotepadDbContext _context;


        public CommandRepository(NotepadDbContext context)
        {
            _context = context;
        }
        private DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var existingEntity = await Table.FindAsync(entity.Id);
            if (existingEntity == null)
            {
                throw new Exception($"{entity} not found");
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);

        }
    }
}
