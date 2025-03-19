using Application.Exceptions;
using MongoDB.Driver.Core.Configuration;

namespace WebAPI.Middleware
{
    public class AccessKeyAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AccessKeyAuthenticationMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<AccessKeyAuthenticationMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? accessKey = Environment.GetEnvironmentVariable("CHRONOSYNC_ACCESS_KEY");

            if (string.IsNullOrEmpty(accessKey))
                throw new MissingEnvironmentVariableException("No accessKey found in environment variables!");

            if (!context.Request.Headers.TryGetValue("X-Access-Key", out var headerKey))
            {
                context.Response.StatusCode = 400; //Bad Request
                await context.Response.WriteAsync("No accessKey was found in the X-Access-Key request header!");
                return;
            }

            if (!IsValidAccessKey(headerKey.ToString(), accessKey))
            {
                context.Response.StatusCode = 401; //Unauthorized
                await context.Response.WriteAsync("An invalid accessKey was submitted within the request header!");
                return;
            }

            await _next(context);
        }

        private bool IsValidAccessKey(string providedKey, string validKey)
        {
            if (providedKey.Length != validKey.Length) return false;

            bool IsValid = false;
            for (int i = 0; i < validKey.Length; i++)
            {
                if (providedKey[i] == validKey[i])
                {
                    IsValid = true;
                }
            }

            return IsValid;
        }
    }
}
