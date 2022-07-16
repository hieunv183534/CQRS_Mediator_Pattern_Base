using FluentValidation;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Commands
{
    public class DeleteCommandValidator : AbstractValidator<DeleteCommand>
    {
        public DeleteCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().WithMessage("Id Không được để trống");
        }
    }
}

