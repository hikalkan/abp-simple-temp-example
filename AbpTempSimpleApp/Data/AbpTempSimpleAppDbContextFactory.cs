using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AbpTempSimpleApp.Data;

public class AbpTempSimpleAppDbContextFactory : IDesignTimeDbContextFactory<AbpTempSimpleAppDbContext>
{
    public AbpTempSimpleAppDbContext CreateDbContext(string[] args)
    {
        AbpTempSimpleAppGlobalFeatureConfigurator.Configure();
        AbpTempSimpleAppModuleExtensionConfigurator.Configure();

        AbpTempSimpleAppEfCoreEntityExtensionMappings.Configure();
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AbpTempSimpleAppDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));

        return new AbpTempSimpleAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}