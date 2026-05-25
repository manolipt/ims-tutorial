using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

using QueryHandler = IQueryHandler<GetInventoryByIdQuery, Inventory?>;

public record GetInventoryByIdQuery(int InventoryId);

public class GetInventoryByIdQueryHandler(IInventoryRepository inventoryRepository) : QueryHandler
{
    async Task<Inventory?> QueryHandler.HandleAsync(GetInventoryByIdQuery query)
    {
        return await inventoryRepository.GetInventoryByIdAsync(query.InventoryId);
    }
}