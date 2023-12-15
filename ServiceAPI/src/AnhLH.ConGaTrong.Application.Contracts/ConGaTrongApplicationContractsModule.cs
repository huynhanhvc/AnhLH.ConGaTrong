using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace AnhLH.ConGaTrong;

[DependsOn(
    typeof(ConGaTrongDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ConGaTrongApplicationContractsModule : AbpModule
{

}
