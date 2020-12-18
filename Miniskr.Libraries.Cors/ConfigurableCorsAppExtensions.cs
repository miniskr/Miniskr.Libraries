using Microsoft.AspNetCore.Builder;

namespace Miniskr.Libraries.Cors
{
    public static class ConfigurableCorsAppExtensions
    {
        public static IApplicationBuilder UseConfigurableCors(this IApplicationBuilder app)
        {
            app.UseCors("ConfigurableCors");

            return app;
        }
    }
}
