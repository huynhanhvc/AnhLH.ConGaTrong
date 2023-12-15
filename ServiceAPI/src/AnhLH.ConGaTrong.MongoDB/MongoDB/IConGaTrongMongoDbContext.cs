using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace AnhLH.ConGaTrong.MongoDB;

[ConnectionStringName(ConGaTrongDbProperties.ConnectionStringName)]
public interface IConGaTrongMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
