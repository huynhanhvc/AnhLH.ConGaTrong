using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AnhLH.ConGaTrong.EntityFrameworkCore;

[DependsOn(
    typeof(ConGaTrongDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ConGaTrongEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ConGaTrongDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
