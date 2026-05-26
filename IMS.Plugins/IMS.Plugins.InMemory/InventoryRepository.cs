using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class InventoryRepository : IRepository<Inventory>
{
    private readonly List<Inventory> _inventories =
    [
        new() { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 2 },
        new() { InventoryId = 2, InventoryName = "Bike Body", Quantity = 10, Price = 15 },
        new() { InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price = 8 },
        new() { InventoryId = 4, InventoryName = "Bike Pedals", Quantity = 20, Price = 1 }
    ];
    
    public Task<Inventory?> GetByIdAsync(int id) => GetInventoryByIdAsync(id);

    public Task<IEnumerable<Inventory>> GetByNameAsync(string name) => GetInventoriesByNameAsync(name);

    public Task AddAsync(Inventory entry) => AddInventoryAsync(entry);

    public Task UpdateAsync(Inventory entry) => UpdateInventoryAsync(entry);

    public Task DeleteByIdAsync(int id) => DeleteInventoryByIdAsync(id);

    private Task<Inventory?> GetInventoryByIdAsync(int inventoryId)
        => Task.FromResult((Inventory?)
            _inventories
                .FirstOrDefault(i => i.InventoryId == inventoryId)
                ?.Clone());

    private async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

        return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    private Task AddInventoryAsync(Inventory inventory)
    {
        // Enforce uniqueness of inventory name
        if (_inventories.Any(x =>
                x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        inventory.InventoryId = _inventories.Max(x => x.InventoryId) + 1;
        _inventories.Add(inventory);

        return Task.CompletedTask;
    }

    private Task UpdateInventoryAsync(Inventory inventory)
    {
        // Enforce uniqueness of inventory name
        if (_inventories.Any(x =>
                x.InventoryId != inventory.InventoryId &&
                x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        var invToUpdate = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);

        if (invToUpdate is null) return Task.CompletedTask;

        invToUpdate.InventoryName = inventory.InventoryName;
        invToUpdate.Price = inventory.Price;
        invToUpdate.Quantity = inventory.Quantity;
        return Task.CompletedTask;
    }

    private Task DeleteInventoryByIdAsync(int inventoryId)
    {
        _inventories.RemoveAll(i => i.InventoryId == inventoryId);
        return Task.CompletedTask;
    }
}