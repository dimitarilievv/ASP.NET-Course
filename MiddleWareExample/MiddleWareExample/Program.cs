using MiddleWareExample.CustomMiddleWare;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleWare>();
var app = builder.Build();

//Middleware 1
app.Use(async (HttpContext context,RequestDelegate next) => {
    await context.Response.WriteAsync("Hello from Middleware 1\n");
    await next(context);
});
//Middleware 2
/*app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello again");
    await next(context);
});
*/
//app.UseMiddleware<MyCustomMiddleWare>();
//app.UseMyCustomMiddleware();
app.UseHelloCustomMiddleware();
//Middleware 3
app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Hello from Middleware 3\n");
});
app.Run();
