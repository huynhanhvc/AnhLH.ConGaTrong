using AnhLH.ConGaTrong.Dtos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AnhLH.ConGaTrong.EntityFrameworkCore;

[ConnectionStringName(ConGaTrongDbProperties.ConnectionStringName)]
public class ConGaTrongDbContext : AbpDbContext<ConGaTrongDbContext>, IConGaTrongDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ConGaTrongDbContext(DbContextOptions<ConGaTrongDbContext> options)
        : base(options)
    {

    }

    public DbSet<Customers> Customers { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<TicketResults> TicketResults { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureConGaTrong();
    }
}
