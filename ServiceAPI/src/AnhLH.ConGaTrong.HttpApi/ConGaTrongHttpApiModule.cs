using AnhLH.ConGaTrong.Localization;
using System.Net;
using AnhLH.ConGaTrong.ExceptionCodes;
using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.ExceptionHandling;

namespace AnhLH.ConGaTrong;

[DependsOn(
    typeof(ConGaTrongApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ConGaTrongHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ConGaTrongHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ConGaTrongResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
        
        Configure<AbpExceptionHttpStatusCodeOptions>(options =>
        {
            options.Map(ExceptionCode.NotFound, HttpStatusCode.NotFound);
            options.Map(ExceptionCode.BadRequest, HttpStatusCode.BadRequest);
            options.Map(ExceptionCode.InternalServerError, HttpStatusCode.InternalServerError);
        });
    }
}
