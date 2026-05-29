using Volo.Abp.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AbpTempSimpleApp.Data;

public class AbpTempSimpleAppDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public AbpTempSimpleAppDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        
        /* We intentionally resolving the AbpTempSimpleAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpTempSimpleAppDbContext>()
            .Database
            .MigrateAsync();

    }
}
