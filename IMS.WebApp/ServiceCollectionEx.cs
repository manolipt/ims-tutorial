using IMS.CoreBusiness;
using Microsoft.AspNetCore.Identity.Data;

namespace IMS.WebApp;

public static class ServiceCollectionEx
{
    public static IServiceCollection AddCommandHandler<TCommand, THandler>(this IServiceCollection services)
        where THandler : class, ICommandHandler<TCommand>
        => services.AddScoped<ICommandHandler<TCommand>, THandler>();
    
    public static IServiceCollection AddCommandHandler<TCommand, TResponse, THandler>(this IServiceCollection services)
        where THandler : class, ICommandHandler<TCommand, TResponse> 
        => services.AddScoped<ICommandHandler<TCommand, TResponse>, THandler>();
    
    public static IServiceCollection AddQueryHandler<TResponse, THandler>(this IServiceCollection services)
        where  THandler : class, IQueryHandler<TResponse>
        => services.AddScoped<IQueryHandler<TResponse>, THandler>();
    
    public static IServiceCollection AddQueryHandler<TQuery, TResponse, THandler>(this IServiceCollection services)
        where THandler : class, IQueryHandler<TQuery, TResponse>
        => services.AddScoped<IQueryHandler<TQuery, TResponse>, THandler>();
}