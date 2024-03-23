using FluentValidation;
using sgv.Core.Services;
using sgv.Core.Services.Interfaces;
using sgv.Persistence;
using sgv.Persistence.Repositories;
using System.Reflection;

namespace sgv.Extensions;

public static class ServiceExtensions
{
    public static void AddConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient<DbConnections>();
        services.AddHttpContextAccessor();
        services.AddTransient<IProductosService, ProductosService>();
        services.AddTransient<IProductosRepository, ProductoRepository>();
    }
}
