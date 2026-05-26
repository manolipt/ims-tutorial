using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Repositories;

public record GetByNameQuery<T>(string Name = "");

internal class GetProductsByNameQueryHandler<T>(IRepository<T> repository) : IQueryHandler<GetByNameQuery<T>, IEnumerable<T>>
{
    async Task<IEnumerable<T>> IQueryHandler<GetByNameQuery<T>, IEnumerable<T>>.HandleAsync(GetByNameQuery<T> query)
    {
        return await repository.GetByNameAsync(query.Name);
    }
}