
using Notepad.Core.Abstractions;

namespace Notepad.DAL.Repositories.Interfaces.Generics
{
    public interface ICommandRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
