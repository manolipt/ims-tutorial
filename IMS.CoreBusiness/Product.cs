namespace IMS.CoreBusiness;

public class Product : ICloneable
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public int Price { get; set; }

    public ICollection<ProductInventory> ProductInventories
    {
        get => field ?? [];
        init;
    } = [];

    public void AddInventory(Inventory inventory)
    {
        if (!ProductInventories.Any(pi =>
                pi.Inventory is not null &&
                pi.Inventory.InventoryName == inventory.InventoryName))
            ProductInventories.Add(new ProductInventory
            {
                InventoryId = inventory.InventoryId,
                Inventory = inventory,
                ProductId = ProductId,
                Product = this,
                InventoryQuantity = 1
            });
    }

    public void RemoveInventory(Inventory inventory)
    {
        if (ProductInventories.Any(pi => pi.InventoryId == inventory.InventoryId))
            ProductInventories.Remove(ProductInventories.First(pi => pi.InventoryId == inventory.InventoryId));
    }

    public object Clone()
        => new Product
        {
            ProductId = ProductId,
            ProductName = ProductName,
            Quantity = Quantity,
            Price = Price,
        };
}