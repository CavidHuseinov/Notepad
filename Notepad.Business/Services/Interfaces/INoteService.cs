
using Notepad.Business.DTOs.Note;

namespace Notepad.Business.Services.Interfaces
{
    public interface INoteService
    {
        Task<ICollection<NoteDto>> GetAllNote();
        Task<NoteDto> GetNoteById(Guid id);
        Task<NoteDto> CreateAsync(CreateNoteDto dto);
        Task<NoteDto> GetNoteWithPassword(Guid id, string? password);
        Task UpdateAsync(UpdateNoteDto dto);
        Task DeleteAsync(Guid id);
        Task DeleteOldNotes();
    }
}
