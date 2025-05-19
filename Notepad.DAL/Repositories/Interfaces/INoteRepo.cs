
using Notepad.Core.Entities;
using Notepad.DAL.Repositories.Interfaces.Generics;

namespace Notepad.DAL.Repositories.Interfaces
{
    public interface INoteRepo:ICommandRepository<Note>
    {
    }
}
