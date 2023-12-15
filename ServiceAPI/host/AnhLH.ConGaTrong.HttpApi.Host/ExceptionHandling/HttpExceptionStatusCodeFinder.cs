using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.DependencyInjection;

namespace AnhLH.ConGaTrong.ExceptionHandling
{
    [Dependency(ReplaceServices = true)]
    public class HttpExceptionStatusCodeFinder :
        DefaultHttpExceptionStatusCodeFinder,
        ITransientDependency
    {
        public HttpExceptionStatusCodeFinder(IOptions<AbpExceptionHttpStatusCodeOptions> options)
            : base(options)
        {
        }
    }
}