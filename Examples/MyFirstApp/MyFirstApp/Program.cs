using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    // context.Response.Headers["MyKey"] = "my value";
    // context.Response.Headers["Server"] = "My server";
    // context.Response.Headers["Content-Type"] = "text/html";
    // await context.Response.WriteAsync("<h1>Hello</h1>");
    // await context.Response.WriteAsync("<h2>World</h2>");
    // string path=context.Request.Path;
    // string method = context.Request.Method;

    // if (method == "GET")
    // {
    // context.Response.Headers["Content-Type"] = "text/html";
    /*   if (context.Request.Query.ContainsKey("id"))
       {
           string id=context.Request.Query["id"];
           await context.Response.WriteAsync($"<p>{id}</p>");
       }
    */
    /*if (context.Request.Headers.ContainsKey("User-Agent"))
    {
        string userAgent = context.Request.Headers["User-Agent"];
        await context.Response.WriteAsync($"<p>{userAgent}</p>");
    }
       if (context.Request.Headers.ContainsKey("AuthorizationKey"))
    {
        string auth = context.Request.Headers["AuthorizationKey"];
        await context.Response.WriteAsync($"<p>{auth}</p>");
    }
    */

    // }
    // await context.Response.WriteAsync($"<p>{path}</p>");
    // await context.Response.WriteAsync($"<p>{method}</p>");
    System.IO.StreamReader reader = new System.IO.StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict =
     Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
    if(queryDict.ContainsKey("firstName"))
    {
        string firstName = queryDict["firstName"][0]; 
        await context.Response.WriteAsync(firstName);
    }
});
//app.MapGet("/", () => "Hello World!");

app.Run();
