
using Notepad.DAL.Context;

namespace Notepad.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NotepadDbContext _context;
        public UnitOfWork(NotepadDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
