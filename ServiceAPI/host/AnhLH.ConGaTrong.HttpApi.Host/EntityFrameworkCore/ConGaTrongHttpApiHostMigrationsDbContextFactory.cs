using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AnhLH.ConGaTrong.EntityFrameworkCore;

public class ConGaTrongHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ConGaTrongHttpApiHostMigrationsDbContext>
{
    public ConGaTrongHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ConGaTrongHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("ConGaTrong"));

        return new ConGaTrongHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
