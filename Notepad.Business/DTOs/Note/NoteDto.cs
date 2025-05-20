
using Notepad.Core.Abstractions;

namespace Notepad.Business.DTOs.Note
{
    public record NoteDto:BaseDto
    {
        public string NoteUrl { get; set; } = default!;
        public string Title {  get; set; } = default!;
        public string? Content { get; set; }

    }
}
