using FluentValidation;

namespace NOM.Domain.Application.Properties.Commands;

/// <summary>
/// haitc 02/06/2022
/// </summary>
public class CreatePropertiesValidator : AbstractValidator<CreatePropertiesCmd>
{
    public CreatePropertiesValidator()
    {
        RuleFor(x => x.PropertyName)
            .NotEmpty().WithMessage("Tên thuộc tính không được để trống")
            .MaximumLength(256).WithMessage("Tên thuộc tính không vượt quá 256 ký tự");
        RuleFor(x => x.PropertyCode)
            .NotEmpty().WithMessage("Mã thuộc tính không được để trống")
            .MaximumLength(36).WithMessage("Mã thuộc tính không vượt quá 36 ký tự");
        RuleFor(x => x.Description)
                     .MaximumLength(500).WithMessage("Mô tả danh mục không vượt quá 500 ký tự");
    }
}

public class UpdatePropertiesValidator : AbstractValidator<UpdatePropertiesCmd>
{
    public UpdatePropertiesValidator()
    {
        RuleFor(x => x.PropertyName)
            .NotEmpty().WithMessage("Tên thuộc tính không được để trống")
            .MaximumLength(256).WithMessage("Tên thuộc tính không vượt quá 256 ký tự");
        RuleFor(x => x.PropertyCode)
            .NotEmpty().WithMessage("Mã thuộc tính không được để trống")
            .MaximumLength(36).WithMessage("Mã thuộc tính không vượt quá 36 ký tự");
        RuleFor(x => x.Description)
                     .MaximumLength(500).WithMessage("Mô tả danh mục không vượt quá 500 ký tự");
    }
}