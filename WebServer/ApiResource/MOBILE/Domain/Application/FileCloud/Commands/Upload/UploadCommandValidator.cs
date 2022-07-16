using FluentValidation;

namespace BCCP.DomainGlobal.Application.FileCloud.Commands
{
    public class UploadCommandValidator : AbstractValidator<UploadCommand>
    {
        public UploadCommandValidator()
        {
            RuleFor(v => v.File).NotEmpty().WithMessage("File Không được để trống");
        }
    }
}
