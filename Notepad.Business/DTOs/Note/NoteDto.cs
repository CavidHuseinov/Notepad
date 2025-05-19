
using Notepad.Core.Abstractions;

namespace Notepad.Business.DTOs.Note
{
    public record NoteDto:BaseDto
    {
        public string NoteUrl { get; set; } = default!;
    }
}
