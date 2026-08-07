namespace IMS.CoreBusiness;

public enum InventoryTransactionType
{
    PurchaseInventory = 1,
    ProductProduct = 2,
}

public class InventoryTransaction : ICloneable
{
    public int Id { get; set; }
    
    public string PurchaseOrderName { get; set; } = string.Empty;
    
    public int InventoryId { get; set; }
    public Inventory? Inventory { get; set; }
    
    public InventoryTransactionType Activity { get; set; }
    
    public int QuantityBefore { get; set; }
    
    public int QuantityAfter { get; set; }
    
    public double UnitPrice { get; set; }
    
    public DateTime TransactionDate { get; set; }
    
    public string DoneBy { get; set; } = string.Empty;

    public object Clone() => new InventoryTransaction
    {
        Id = Id,
        PurchaseOrderName = PurchaseOrderName,
        InventoryId = InventoryId,
        Inventory = (Inventory?)Inventory?.Clone(),
        Activity = Activity,
        QuantityBefore = QuantityBefore,
        QuantityAfter = QuantityAfter,
        UnitPrice = UnitPrice,
        TransactionDate = TransactionDate,
        DoneBy = DoneBy,
    };
}
