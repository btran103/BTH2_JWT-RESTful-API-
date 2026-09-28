using Microsoft.AspNetCore.Authentication;

namespace JwtApi.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = await context.GetTokenAsync("access_token");

            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("Không tìm thấy JWT");
            }
            else
            {
                Console.WriteLine("Đã nhận JWT");
            }

            await _next(context);
        }
    }
}