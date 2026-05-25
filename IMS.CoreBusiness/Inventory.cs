namespace IMS.CoreBusiness;

public class Inventory : ICloneable
{
    public int InventoryId { get; set; }

    public string InventoryName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public int Price { get; set; }

    public object Clone()
        => new Inventory
        {
            InventoryId = InventoryId,
            InventoryName = InventoryName,
            Quantity = Quantity,
            Price = Price,
        };
}