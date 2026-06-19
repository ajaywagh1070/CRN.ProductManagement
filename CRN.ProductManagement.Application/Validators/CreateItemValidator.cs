using CRN.ProductManagement.Application.DTOs;
using FluentValidation;

namespace CRN.ProductManagement.Application.Validators;

public class CreateItemValidator : AbstractValidator<CreateItemDto>
{
    public CreateItemValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0);

        RuleFor(x => x.Quantity)
            .GreaterThan(0);
    }
}