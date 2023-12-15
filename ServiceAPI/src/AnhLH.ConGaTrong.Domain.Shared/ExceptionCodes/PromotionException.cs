using System;
using System.Runtime.Serialization;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Logging;

namespace AnhLH.CustomerEventsAPI.ExceptionCodes
{
    [Serializable]
    public class AnhLHValidationException : Exception, IHasErrorCode, IHasErrorDetails, IHasLogLevel, IUserFriendlyException
    {
        public string Code { get; set; }
        public string Details { get; set; }

        public LogLevel LogLevel { get; set; }

        public AnhLHValidationException(
            string code = null,
            string message = null,
            string details = null,
            Exception innerException = null,
            LogLevel logLevel = LogLevel.Error) : base(message, innerException)
        {

            Code = code;
            Details = details;
            LogLevel = logLevel;
        }

        public AnhLHValidationException(SerializationInfo serializationInfo, StreamingContext context) : base(
            serializationInfo, context)
        {

        }

        public AnhLHValidationException WithData(string name, object value)
        {
            Data[name] = value;
            return this;
        }
    }
}