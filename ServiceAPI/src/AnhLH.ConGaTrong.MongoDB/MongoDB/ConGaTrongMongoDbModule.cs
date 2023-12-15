using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace AnhLH.ConGaTrong.MongoDB;

[DependsOn(
    typeof(ConGaTrongDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class ConGaTrongMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<ConGaTrongMongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
