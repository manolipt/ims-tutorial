using System.Text.Json.Serialization;

namespace IMS.CoreBusiness;

public class ProductInventory : ICloneable
{
    public int ProductId { get; init; }

    [JsonIgnore] public Product? Product { get; init; }

    public int InventoryId { get; init; }

    [JsonIgnore] public Inventory? Inventory { get; init; }

    public int InventoryQuantity { get; set; }

    public object Clone()
        => new ProductInventory
        {
            ProductId = ProductId,
            Product = (Product?)Product?.Clone(),
            InventoryId = InventoryId,
            Inventory = (Inventory?)Inventory?.Clone(),
            InventoryQuantity = InventoryQuantity,
        };
}