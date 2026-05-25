using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

using QueryHandler = IQueryHandler<GetInventoriesByNameQuery, IEnumerable<Inventory>>;

public record GetInventoriesByNameQuery(string Name = "");

internal class GetInventoriesByNameQueryHandler(IInventoryRepository inventoryRepository) : QueryHandler
{
    async Task<IEnumerable<Inventory>> QueryHandler.HandleAsync(GetInventoriesByNameQuery query)
    {
        return await inventoryRepository.GetInventoriesByNameAsync(query.Name);
    }
}