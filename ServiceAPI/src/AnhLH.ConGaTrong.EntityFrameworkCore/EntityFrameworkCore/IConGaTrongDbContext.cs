using AnhLH.ConGaTrong.Dtos;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AnhLH.ConGaTrong.EntityFrameworkCore;

[ConnectionStringName(ConGaTrongDbProperties.ConnectionStringName)]
public interface IConGaTrongDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    DbSet<Customers> Customers { get; }
    DbSet<Orders> Orders { get; }
    DbSet<TicketResults> TicketResults { get; }
}
