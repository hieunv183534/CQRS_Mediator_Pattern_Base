using FluentValidation;

namespace NOM.Domain.Application.Categories.Commands;

/// <summary>
/// haitc 02/06/2022
/// </summary>
public class CreateCategoryValidator : AbstractValidator<CreateCategoriesCmd>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Tên danh mục không được để trống")
            .MaximumLength(256).WithMessage("Tên danh mục không vượt quá 256 ký tự");
        RuleFor(x => x.Description)
                     .MaximumLength(500).WithMessage("Mô tả danh mục không vượt quá 500 ký tự");
        RuleFor(x => x.CategoryTypeId)
                .NotEmpty().WithMessage("Kiểu danh mục không được để trống");
    }
}

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoriesCmd>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.CategoryId)
               .NotEmpty().WithMessage("Id danh mục không được để trống");
        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Tên danh mục không được để trống")
            .MaximumLength(256).WithMessage("Tên danh mục không vượt quá 256 ký tự");
        RuleFor(x => x.Description)
                     .MaximumLength(500).WithMessage("Mô tả danh mục không vượt quá 500 ký tự");
        RuleFor(x => x.CategoryTypeId)
                .NotEmpty().WithMessage("Kiểu danh mục không được để trống");
    }
}

public class DeleteCategoryValidator : AbstractValidator<DeleteCategoriesCmd>
{
    public DeleteCategoryValidator()
    {
        RuleFor(x => x.CategoryId)
               .NotEmpty().WithMessage("Id danh mục không được để trống");
    }
}