
using Notepad.Business.Services.Interfaces;

namespace Notepad.Infrastructure.BackgroundJobs
{
    public class NoteJobs
    {
        private readonly INoteService _service;

        public NoteJobs(INoteService service)
        {
            _service = service;
        }

        public async Task DeleteOldNotesJob()
        {
            await _service.DeleteOldNotes();
        }
    }
}
