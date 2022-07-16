using FluentValidation;

namespace BCCP.DomainGlobal.Application.FileCloud.Commands
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            //RuleFor(v => v.ColText).MaximumLength(255).WithMessage("Tối đa 255 ký tự");
            //RuleFor(v => v.ColText).NotEmpty().WithMessage("Không được để trống");
        }
    }
}
