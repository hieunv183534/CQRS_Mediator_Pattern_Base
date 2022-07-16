using FluentValidation;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerDataSet.Commands
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            
            
            RuleFor(v => v.Name).MaximumLength(255).WithMessage("Tối đa 255 ký tự");

            
            
            
            RuleFor(v => v.ConnectString).MaximumLength(50).WithMessage("Tối đa 50 ký tự");

        }
    }
}
