using sgv.Middlewares;

namespace sgv.Extensions;

public static class AppExtensions
{
    public static void UseHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ManejadorErroresMiddleware>();
    }
}
