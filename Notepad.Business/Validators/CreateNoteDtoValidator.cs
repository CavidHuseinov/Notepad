
using FluentValidation;
using Notepad.Business.DTOs.Note;

namespace Notepad.Business.Validators
{
    public class CreateNoteDtoValidator : AbstractValidator<CreateNoteDto>
    {
        public CreateNoteDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Notunuza başlıq verin əks təqdirdə yaratmaq mümkün deyil.");
            RuleFor(x => x.Password).MinimumLength(1).WithMessage("Şifrəniz minimum 1 simvoldan ibarət olmalıdır.");
        }
    }
}
