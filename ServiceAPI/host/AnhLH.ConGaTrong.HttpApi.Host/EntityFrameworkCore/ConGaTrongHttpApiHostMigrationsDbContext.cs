using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AnhLH.ConGaTrong.EntityFrameworkCore;

public class ConGaTrongHttpApiHostMigrationsDbContext : AbpDbContext<ConGaTrongHttpApiHostMigrationsDbContext>
{
    public ConGaTrongHttpApiHostMigrationsDbContext(DbContextOptions<ConGaTrongHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureConGaTrong();
    }
}
