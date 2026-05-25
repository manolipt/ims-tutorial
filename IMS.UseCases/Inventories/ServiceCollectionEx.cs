using IMS.CoreBusiness;
using Microsoft.Extensions.DependencyInjection;

namespace IMS.UseCases.Inventories;

public static class ServiceCollectionEx
{
    public static void AddInventoryFeatures(this IServiceCollection services)
    {
        services.AddQueryHandler<GetInventoryByIdQuery, Inventory?, GetInventoryByIdQueryHandler>();
        services.AddQueryHandler<
            GetInventoriesByNameQuery,
            IEnumerable<Inventory>,
            GetInventoriesByNameQueryHandler>();
        services.AddCommandHandler<AddInventoryCommand, AddInventoryCommandHandler>();
        services.AddCommandHandler<EditInventoryCommand, EditInventoryCommandHandler>();
        services.AddCommandHandler<DeleteInventoryByIdCommand, DeleteInventoryByIdCommandHandler>();
    }
}