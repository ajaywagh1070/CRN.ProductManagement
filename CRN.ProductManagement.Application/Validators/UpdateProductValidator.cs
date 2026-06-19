using CRN.ProductManagement.Application.DTOs;
using FluentValidation;

namespace CRN.ProductManagement.Application.Validators;

public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty()
            .MaximumLength(255);
    }
}