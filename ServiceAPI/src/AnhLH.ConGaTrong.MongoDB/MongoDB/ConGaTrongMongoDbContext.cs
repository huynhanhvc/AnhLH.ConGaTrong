using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace AnhLH.ConGaTrong.MongoDB;

[ConnectionStringName(ConGaTrongDbProperties.ConnectionStringName)]
public class ConGaTrongMongoDbContext : AbpMongoDbContext, IConGaTrongMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureConGaTrong();
    }
}
