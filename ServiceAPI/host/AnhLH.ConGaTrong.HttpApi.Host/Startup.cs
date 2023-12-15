using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace AnhLH.ConGaTrong;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<ConGaTrongHttpApiHostModule>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        app.ApplicationServices.GetService<ISettingDefinitionManager>()!.Get(LocalizationSettingNames.DefaultLanguage).DefaultValue = "vi";
        app.InitializeApplication();
    }
}