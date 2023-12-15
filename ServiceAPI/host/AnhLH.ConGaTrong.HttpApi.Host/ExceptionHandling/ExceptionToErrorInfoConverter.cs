using System;
using AnhLH.ConGaTrong.ExceptionCodes;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ExceptionHandling.Localization;
using Volo.Abp.Http;
using Volo.Abp.Localization.ExceptionHandling;

namespace AnhLH.ConGaTrong.ExceptionHandling
{
    [Dependency(ReplaceServices = true)]
    public class ExceptionToErrorInfoConverter :
        DefaultExceptionToErrorInfoConverter,
        ITransientDependency
    {
        public ExceptionToErrorInfoConverter(
                IOptions<AbpExceptionLocalizationOptions> localizationOptions,
                IStringLocalizerFactory stringLocalizerFactory,
                IStringLocalizer<AbpExceptionHandlingResource> abpUiStringLocalizer,
                IServiceProvider serviceProvider)
            : base(localizationOptions, stringLocalizerFactory, abpUiStringLocalizer, serviceProvider)
        {
        }


        protected override RemoteServiceErrorInfo CreateErrorInfoWithoutCode(Exception exception, AbpExceptionHandlingOptions options)
        {
            var code = exception.GetType()?.GetProperty("Code")?.GetValue(exception);
            if (code == null)
            {
                return new ExtensibleRemoteServiceErrorInfo
                 (
                     code: ExceptionCode.InternalServerError,
                     message: "Có lỗi xảy ra trong quá trình xử lý!",
                     details: exception.Message
                 );
            }

            options.SendExceptionsDetailsToClients = false;
            options.SendStackTraceToClients = false;
            return base.CreateErrorInfoWithoutCode(exception, options);
        }
    }
}