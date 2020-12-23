using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace MentoringProgram.Middleware
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerFactory _loggerFactory;

        public LogRequestMiddleware(RequestDelegate next, ILoggerFactory loggerFactor)
        {
            this.next = next;
            _loggerFactory = loggerFactor;
        }

        public async Task Invoke(HttpContext context)
        {
            var _logger = _loggerFactory.CreateLogger<LogRequestMiddleware>();
            var requestBodyStream = new MemoryStream();
            var originalRequestBody = context.Request.Body;

            await context.Request.Body.CopyToAsync(requestBodyStream);
            requestBodyStream.Seek(0, SeekOrigin.Begin);

            var url = UriHelper.GetDisplayUrl(context.Request);
            var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();
            _logger.Log(LogLevel.Information, $"REQUEST METHOD: {context.Request.Method}, REQUEST BODY: {requestBodyText}, REQUEST URL: {url}");

            requestBodyStream.Seek(0, SeekOrigin.Begin);
            context.Request.Body = requestBodyStream;

            await next(context);
            context.Request.Body = originalRequestBody;
        }
    }
}
