using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories;

using QueryHandler = IQueryHandler<ViewInventoriesByNameQuery, IEnumerable<Inventory>>;

public record ViewInventoriesByNameQuery(string Name = "");

public class ViewInventoriesByNameQueryHandler(IInventoryRepository inventoryRepository) : QueryHandler
{
    async Task<IEnumerable<Inventory>> QueryHandler.HandleAsync(ViewInventoriesByNameQuery query)
    {
        return await inventoryRepository.GetInventoriesByNameAsync(query.Name);
    }
}