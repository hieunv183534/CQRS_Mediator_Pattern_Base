using FluentValidation;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerGroupBy.Commands
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            
            
            RuleFor(v => v.Name).NotEmpty().WithMessage("Không được để trống");
RuleFor(v => v.Name).MaximumLength(255).WithMessage("Tối đa 255 ký tự");

            RuleFor(v => v.Path).NotEmpty().WithMessage("Không được để trống");
RuleFor(v => v.Path).MaximumLength(255).WithMessage("Tối đa 255 ký tự");

            RuleFor(v => v.Key).NotEmpty().WithMessage("Không được để trống");
RuleFor(v => v.Key).MaximumLength(300).WithMessage("Tối đa 300 ký tự");

        }
    }
}
