using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness.Validations;

public class ProductPriceIsGreaterThanInventoriesCost : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext? context)
    {
        if (context?.ObjectInstance is Product product && !PriceIsValid(product))
        {
            return new ValidationResult(ErrorMessage ??
                $"Product price ({product.Price:c}) must be greater than inventory cost ({TotalInventoriesCost(product):c}).");
        }

        return ValidationResult.Success;
    }

    private static double TotalInventoriesCost(Product product)
        => product.ProductInventories.Sum(pi => pi.Inventory?.Price * pi.InventoryQuantity ?? 0);

    private static bool PriceIsValid(Product product)
        => product.Price > TotalInventoriesCost(product);
}