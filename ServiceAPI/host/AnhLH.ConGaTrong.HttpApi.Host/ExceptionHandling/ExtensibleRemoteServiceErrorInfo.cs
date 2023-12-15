using Volo.Abp.Data;
using Volo.Abp.Http;

namespace AnhLH.ConGaTrong.ExceptionHandling
{
    public class ExtensibleRemoteServiceErrorInfo : RemoteServiceErrorInfo, IHasExtraProperties
    {
        public ExtraPropertyDictionary ExtraProperties { get; set; }
        public ExtensibleRemoteServiceErrorInfo() { }

        public ExtensibleRemoteServiceErrorInfo(string message, string details = null, string code = null)
            : base(message, details, code)
        {
        }
    }
}