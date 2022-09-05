using Entities;
using FluentValidation;

namespace API;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Price).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
        
    }
}