using System.Net;
using System.Text.Json;
using OpenSeaWebApi.Errors;

namespace OpenSeaWebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                //! This is to determine the error output dependent on whether it is DEV or Product Mode
                //var response = _env.IsDevelopment()
                //    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                //    : new ApiException(context.Response.StatusCode, "Internal Server Error");
                var response = new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString());

                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
} 