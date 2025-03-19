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


            if (!context.Request.Headers.TryGetValue("X-Access-Key", out var accessKey))
            {
                context.Response.StatusCode = 400; // Bad Request
                await context.Response.WriteAsync("Access key is missing in the request header.");
                return;
            }

            if (!IsValidAccessKey(accessKey, Environment.GetEnvironmentVariable("CHRONOSYNC_ACCESS_KEY")))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Invalid access key.");
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
