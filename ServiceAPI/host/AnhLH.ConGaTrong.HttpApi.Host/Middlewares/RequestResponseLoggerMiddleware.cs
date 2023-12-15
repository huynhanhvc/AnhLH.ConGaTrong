using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AnhLH.ConGaTrong.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;

namespace Customize.Logging;

public class RequestResponseLoggerMiddleware : IMiddleware, ITransientDependency
{
       private readonly bool _isRequestResponseLoggingEnabled;
        private readonly ILogger _logger;
        private readonly List<string> _ignorePatterns;

        public RequestResponseLoggerMiddleware(IConfiguration config,
            ILogger<RequestResponseLoggerMiddleware> logger)
        {
            _isRequestResponseLoggingEnabled = config.GetValue<bool>("EnableRequestResponseLogging", false);
            _logger = logger;

            _ignorePatterns = config.GetSection("IgnorePatterns").Get<List<string>>() ?? new List<string>();
        }

        private static string FormatHeaders(IHeaderDictionary headers) => string.Join(", ",
            headers.Select(kvp => $"{{{kvp.Key}: {string.Join(", ", kvp.Value)}}}"));

        private static async Task<string> ReadBodyFromRequest(HttpRequest request)
        {
            // Ensure the request's body can be read multiple times (for the next middlewares in the pipeline).
            request.EnableBuffering();

            using var streamReader = new StreamReader(request.Body, leaveOpen: true);
            var requestBody = await streamReader.ReadToEndAsync();

            // Reset the request's body stream position for next middleware in the pipeline.
            request.Body.Position = 0;
            return requestBody;
        }
		
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (_isRequestResponseLoggingEnabled && context.Request.Path != "/")
            {
                var isIgnore = _ignorePatterns.Any(w => Regex.IsMatch(context.Request.Path, w));
                if (!isIgnore)
                {
                    var logs = new TemplateMiddlewareLog
                    {
                        StartDate = DateTime.Now,
                        Host = context.Request.Scheme + "://" + context.Request.Host.ToString(),
                        Path = context.Request.Path,
                        QueryString = context.Request.QueryString.ToString(),
                        Method = context.Request.Method,
                        BodyRequest = await ReadBodyFromRequest(context.Request)
                    };
                    var start = DateTime.Now;
                    // Temporarily replace the HttpResponseStream, which is a write-only stream, with a MemoryStream to capture it's value in-flight.
                    var originalResponseBody = context.Response.Body;
                    using var newResponseBody = new MemoryStream();
                    context.Response.Body = newResponseBody;

                    // Call the next middleware in the pipeline
                    await next(context);
                    newResponseBody.Seek(0, SeekOrigin.Begin);
                    var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                    var end = DateTime.Now;
                    logs.StatusCode = context.Response.StatusCode;
                    logs.BodyResponse = responseBodyText;
                    logs.ExecutionTime = (end - start).TotalMilliseconds;
                    logs.FullPath =
                    $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}" +
                    (!logs.QueryString.IsNullOrEmpty() ? $"{logs.QueryString}" : String.Empty);
                    _logger.LogInformation(
                        "RequestResponseLoggerMiddleware {StartDate} {Host} {Path} {QueryString} {FullPath} {Method} {BodyRequest} {StatusCode} {BodyResponse} {ExecutionTime} {CorrelationId}",
                        logs.StartDate,
                        logs.Host,
                        logs.Path,
                        logs.QueryString,
                        logs.FullPath,
                        logs.Method,
                        logs.BodyRequest,
                        logs.StatusCode,
                        logs.BodyResponse,
                        logs.ExecutionTime,
                        context?.Request?.Headers["X-Correlation-Id"]);
                    newResponseBody.Seek(0, SeekOrigin.Begin);
                    await newResponseBody.CopyToAsync(originalResponseBody);
                }
                else
                {
                    await next(context);
                }
            }
            else
            {
                await next(context);
            }
        }
}