using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class InventoryTransactionRepository : IRepository<InventoryTransaction>
{
    private List<InventoryTransaction> _transactions = [];
    
    public Task<InventoryTransaction?> GetByIdAsync(int id)
        => Task.FromResult((InventoryTransaction?)
            _transactions
                .FirstOrDefault(t => t.Id == id)
                ?.Clone());

    public async Task<IEnumerable<InventoryTransaction>> GetByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_transactions);

        return _transactions.Where(t => t.PurchaseOrderName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public Task AddAsync(InventoryTransaction entry)
    {
        if (_transactions.Any(t => t.Id == entry.Id))
            return Task.CompletedTask;
        
        entry.Id = _transactions.Max(t => t.Id) + 1;
        _transactions.Add(entry);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(InventoryTransaction entry)
    {
        // Enforce uniqueness of PO name
        if (_transactions.Any(t =>
                t.Id != entry.Id &&
                t.PurchaseOrderName.Equals(entry.PurchaseOrderName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;
        
        var transactionToUpdate = _transactions.FirstOrDefault(t => t.Id == entry.Id);
        if (transactionToUpdate is null) return Task.CompletedTask;

        transactionToUpdate.PurchaseOrderName = entry.PurchaseOrderName;
        transactionToUpdate.InventoryId = entry.InventoryId;
        transactionToUpdate.Inventory = entry.Inventory;
        transactionToUpdate.Activity = entry.Activity;
        transactionToUpdate.QuantityBefore = entry.QuantityBefore;
        transactionToUpdate.QuantityAfter = entry.QuantityAfter;
        transactionToUpdate.UnitPrice = entry.UnitPrice;
        transactionToUpdate.TransactionDate = entry.TransactionDate;
        transactionToUpdate.DoneBy = entry.DoneBy;
        
        return Task.CompletedTask;
    }

    public Task DeleteByIdAsync(int id)
    {
        _transactions.RemoveAll(t => t.Id == id);
        return Task.CompletedTask;
    }
}