namespace MiddleWareExample.CustomMiddleWare
{
    public class MyCustomMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custom Middleware - starts\n");
            await next(context);
            await context.Response.WriteAsync("My Custom Middleware - ends\n");
        }
    }
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleWare>();
        }
    }
}
