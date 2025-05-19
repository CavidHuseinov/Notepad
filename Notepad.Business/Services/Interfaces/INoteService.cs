
using Notepad.Business.DTOs.Note;

namespace Notepad.Business.Services.Interfaces
{
    public interface INoteService
    {
        Task<ICollection<NoteDto>> GetAllNote();
        Task<NoteDto> GetNoteById(Guid id);
        Task<NoteDto> CreateAsync(CreateNoteDto dto);
        Task UpdateAsync(UpdateNoteDto dto);
        Task DeleteAsync(Guid id);
    }
}
