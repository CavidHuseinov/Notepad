
using Notepad.Core.Abstractions;

namespace Notepad.Core.Entities
{
    public class Note:BaseEntity
    {
        public string? Title {  get; set; }
        public string? Content { get; set; }
        public bool SecureStatus { get; set; } 
        public string? PasswordHash {  get; set; }
        public string? NoteUrl { get; set; }
    }
}
