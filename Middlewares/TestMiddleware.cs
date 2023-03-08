// create middleware

// Path: Middlewares/TestMiddleware.cs


using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AspNetAPI.Middlewares
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
            Console.WriteLine("TestMiddleware");
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("TestMiddleware invoke");
            await _next(context);
        }
    }

    public static class TestMiddlewareExtensions
    {
        public static IApplicationBuilder UseTestMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TestMiddleware>();
        }
    }
}