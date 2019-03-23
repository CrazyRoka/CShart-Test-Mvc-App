using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MenuPlaner
{
    public static class EnsureMigration
    {
        public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T : DbContext
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<T>();
                context.Database.Migrate();
            }
        }
    }
}
