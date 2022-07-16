using FluentValidation;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerGroupBy.Commands
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        public UpdateCommandValidator()
        {


            RuleFor(v => v.Name).NotEmpty().WithMessage("Không được để trống");
            RuleFor(v => v.Name).MaximumLength(255).WithMessage("Tối đa 255 ký tự");

            RuleFor(v => v.DataSetId).NotEmpty().WithMessage("Không được để trống");

            RuleFor(v => v.Key).NotEmpty().WithMessage("Không được để trống");
            RuleFor(v => v.Key).MaximumLength(300).WithMessage("Tối đa 300 ký tự");

        }
    }
}
