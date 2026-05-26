using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IMS.UseCases;

public static class ServiceCollectionEx
{
    public static void AddRepositoryFeaturesFor<TEntry, TRepository>(this IServiceCollection services)
        where TRepository : class, IRepository<TEntry>
    {
        services.AddSingleton<IRepository<TEntry>, TRepository>();
        services.AddQueryHandler<GetByIdQuery<TEntry>, TEntry?, GetByIdQueryHandler<TEntry>>();
        services.AddQueryHandler<GetByNameQuery<TEntry>, IEnumerable<TEntry>, GetProductsByNameQueryHandler<TEntry>>();
        services.AddCommandHandler<AddEntryCommand<TEntry>, AddEntryCommandHandler<TEntry>>();
        services.AddCommandHandler<EditEntryCommand<TEntry>, EditEntryCommandHandler<TEntry>>();
        services.AddCommandHandler<DeleteByIdCommand<TEntry>, DeleteByIdCommandHandler<TEntry>>();
    }

    public static IServiceCollection AddCommandHandler<TCommand, THandler>(this IServiceCollection services)
        where THandler : class, ICommandHandler<TCommand>
    {
        return services.AddScoped<ICommandHandler<TCommand>, THandler>();
    }

    public static IServiceCollection AddCommandHandler<TCommand, TResponse, THandler>(this IServiceCollection services)
        where THandler : class, ICommandHandler<TCommand, TResponse>
    {
        return services.AddScoped<ICommandHandler<TCommand, TResponse>, THandler>();
    }

    public static IServiceCollection AddQueryHandler<TResponse, THandler>(this IServiceCollection services)
        where THandler : class, IQueryHandler<TResponse>
    {
        return services.AddScoped<IQueryHandler<TResponse>, THandler>();
    }

    public static IServiceCollection AddQueryHandler<TQuery, TResponse, THandler>(this IServiceCollection services)
        where THandler : class, IQueryHandler<TQuery, TResponse>
    {
        return services.AddScoped<IQueryHandler<TQuery, TResponse>, THandler>();
    }
}