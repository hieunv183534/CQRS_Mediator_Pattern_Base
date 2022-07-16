using FluentValidation;

namespace NOM.Domain.Application.CategoryTypes.Commands;

/// <summary>
/// haitc 02/06/2022
/// </summary>
public class CreateCategoryTypeValidator : AbstractValidator<CreateCategoriesTypeCmd>
{
    public CreateCategoryTypeValidator()
    {
        RuleFor(x => x.CategoryTypeName)
            .NotEmpty().WithMessage("Tên kiểu danh mục không được để trống")
            .MaximumLength(256).WithMessage("Tên kiểu danh mục không vượt quá 256 ký tự");
        RuleFor(x => x.Description)
                     .MaximumLength(500).WithMessage("Mô tả kiểu danh mục không vượt quá 500 ký tự");
    }
}

public class UpdateCategoryTypeValidator : AbstractValidator<UpdateCategoriesTypeCmd>
{
    public UpdateCategoryTypeValidator()
    {
        RuleFor(x => x.CategoryTypeId)
               .NotEmpty().WithMessage("Id kiểu danh mục không được để trống");
        RuleFor(x => x.CategoryTypeName)
            .NotEmpty().WithMessage("Tên kiểu danh mục không được để trống")
            .MaximumLength(256).WithMessage("Tên kiểu danh mục không vượt quá 256 ký tự");
        RuleFor(x => x.Description)
                     .MaximumLength(500).WithMessage("Mô tả kiểu danh mục không vượt quá 500 ký tự");
    }

    public class DeleteCategoryTypeValidator : AbstractValidator<DeleteCategoriesTypeCmd>
    {
        public DeleteCategoryTypeValidator()
        {
            RuleFor(x => x.CategoryTypeId)
                   .NotEmpty().WithMessage("Id kiểu danh mục không được để trống");
        }
    }
}