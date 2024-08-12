using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace LoginWithMiddleware.CustomMiddleware

{
    public class LoginMiddleware

    {

        private readonly RequestDelegate _next;

        string validEmail = "admin@example.com";

        string validPassword = "admin1234";

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }



        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Method == "POST")
            {
                StreamReader sr = new StreamReader(httpContext.Request.Body);
                string body = await sr.ReadToEndAsync();
                Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
                if (queryDict.ContainsKey("email") && queryDict.ContainsKey("password"))
                {
                    if (Convert.ToString(queryDict["email"][0]) == validEmail && Convert.ToString(queryDict["password"][0]) == validPassword)
                        await httpContext.Response.WriteAsync("Successful login\n");
                    else
                    {
                        await httpContext.Response.WriteAsync("Invalid login\n");
                    }
                }
                else
                    await httpContext.Response.WriteAsync("Invalid input\n");
            }
            else
                await httpContext.Response.WriteAsync("Not POST method");
            await _next(httpContext);

        }

    }


    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
           return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
