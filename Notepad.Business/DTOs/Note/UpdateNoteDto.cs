
using Notepad.Core.Abstractions;

namespace Notepad.Business.DTOs.Note
{
    public record UpdateNoteDto:BaseDto
    {
        public string? Title {  get; set; }
        public string? Content { get; set; }
    }   
}
