using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace AnhLH.ConGaTrong;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ConGaTrongDomainSharedModule)
)]
public class ConGaTrongDomainModule : AbpModule
{

}
