using IMS.CoreBusiness;

namespace IMS.WebApp;

public static class ServiceCollectionEx
{
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