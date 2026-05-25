using System.ComponentModel.DataAnnotations;
using IMS.CoreBusiness.Validations;

namespace IMS.CoreBusiness;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    [StringLength(150)]
    public string ProductName { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 0")]
    public int Quantity { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Price must be greater than or equal to 0")]
    public int Price { get; set; }
    
    [ProductPriceIsGreaterThanInventoriesCost]
    public ICollection<ProductInventory> ProductInventories { get; set; } = [];

    public void AddInventory(Inventory inventory)
    {
        if (!ProductInventories.Any(pi =>
                pi.Inventory is not null &&
                pi.Inventory.InventoryName == inventory.InventoryName))
        {
            ProductInventories.Add(new ProductInventory
            {
                InventoryId = inventory.InventoryId,
                Inventory = inventory,
                ProductId = ProductId,
                Product = this,
                InventoryQuantity = 1,
            });
        }
    }

    public void RemoveInventory(Inventory inventory)
    {
        if (ProductInventories.Any(pi => pi.InventoryId == inventory.InventoryId))
        {
            ProductInventories.Remove(ProductInventories.First(pi => pi.InventoryId == inventory.InventoryId));
        }
    }
}
