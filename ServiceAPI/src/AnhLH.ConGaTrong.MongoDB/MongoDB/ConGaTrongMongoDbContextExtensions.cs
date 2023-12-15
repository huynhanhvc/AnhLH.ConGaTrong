using Volo.Abp;
using Volo.Abp.MongoDB;

namespace AnhLH.ConGaTrong.MongoDB;

public static class ConGaTrongMongoDbContextExtensions
{
    public static void ConfigureConGaTrong(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
