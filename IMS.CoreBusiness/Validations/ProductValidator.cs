using FluentValidation;

namespace IMS.CoreBusiness.Validations;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.ProductName)
            .NotEmpty().WithMessage("Product Name is required")
            .MaximumLength(150).WithMessage("Product Name cannot exceed 150 characters");

        RuleFor(p => p.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than or equal to 0");

        RuleFor(p => p.Price)
            // ReSharper disable once PossiblyMistakenUseOfInterpolatedStringInsert
            .GreaterThanOrEqualTo(0).WithMessage($"Price must be greater than or equal to {0:C}");

        RuleFor(p => p.Price)
            .GreaterThanOrEqualTo(p => TotalCostOfInventories(p))
            .WithMessage((product, price) =>
                $"Product price {price:c} must be greater than total inventory cost {TotalCostOfInventories(product):c}");
    }

    private static int TotalCostOfInventories(Product product)
    {
        return product.ProductInventories.Sum(GetInventoryPrice);
    }

    private static int GetInventoryPrice(ProductInventory productInventory)
    {
        return productInventory.Inventory?.Price ?? 0;
    }
}