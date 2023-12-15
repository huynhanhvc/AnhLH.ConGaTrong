using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace AnhLH.ConGaTrong;

[DependsOn(
    typeof(ConGaTrongApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ConGaTrongHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ConGaTrongApplicationContractsModule).Assembly,
            ConGaTrongRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ConGaTrongHttpApiClientModule>();
        });

    }
}
