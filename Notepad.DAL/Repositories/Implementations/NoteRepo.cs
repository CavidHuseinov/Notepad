
using Notepad.Core.Entities;
using Notepad.DAL.Context;
using Notepad.DAL.Repositories.Implementations.Generics;
using Notepad.DAL.Repositories.Interfaces;

namespace Notepad.DAL.Repositories.Implementations
{
    public class NoteRepo : CommandRepository<Note>, INoteRepo
    {
        public NoteRepo(NotepadDbContext context) : base(context)
        {
        }
    }
}
