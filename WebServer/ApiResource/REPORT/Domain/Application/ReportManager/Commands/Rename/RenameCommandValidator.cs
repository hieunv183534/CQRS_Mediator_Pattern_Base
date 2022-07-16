using FluentValidation;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Commands
{
    public class RenameCommandValidator : AbstractValidator<UpdateCommand>
    {
        public RenameCommandValidator()
        {
            //RuleFor(v => v.ColText).MaximumLength(255).WithMessage("Tối đa 255 ký tự");
            //RuleFor(v => v.ColText).NotEmpty().WithMessage("Không được để trống");
        }
    }
}
