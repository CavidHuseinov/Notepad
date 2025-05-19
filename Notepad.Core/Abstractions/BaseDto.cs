
namespace Notepad.Core.Abstractions
{
    public abstract record BaseDto
    {
        public Guid Id { get; set; }
        public string CreatedAt { get; set; } = default!;
    }
}
