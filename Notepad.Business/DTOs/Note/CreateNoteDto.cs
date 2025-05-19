
namespace Notepad.Business.DTOs.Note
{
    public record CreateNoteDto
    {
        public string Title { get; set; } = default!;
        public string? Content { get; set; }
        public bool SecureStatus {  get; set; }
        public string? Password { get; set; }
    }
}
