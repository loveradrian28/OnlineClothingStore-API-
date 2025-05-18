using FluentValidation;

namespace OnlineClothingStore.Core;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(p => p.Size).NotEmpty().WithMessage("Size is required.");
        RuleFor(p => p.Color).NotEmpty().WithMessage("Color is required.");
        RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        RuleFor(p => p.Description).NotEmpty().WithMessage("Description is required.");
    }
}