using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Repositories;

public record AddEntryCommand<T>(T Entry);

internal class AddEntryCommandHandler<T>(IRepository<T> repository) : ICommandHandler<AddEntryCommand<T>>
{
    async Task ICommandHandler<AddEntryCommand<T>>.HandleAsync(AddEntryCommand<T> request)
    {
        await repository.AddAsync(request.Entry);
    }
}