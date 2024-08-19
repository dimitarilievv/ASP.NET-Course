using RoutingExample.CustomConstraints;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddRouting(options => {
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraits));
});
app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
    if(endpoint != null)
    {
        await context.Response.WriteAsync($"Endpoint:{endpoint.DisplayName}\n");
    }
    await next(context);
    //here it returns null
});

//enable routing
app.UseRouting();

app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
    if (endpoint != null)
    {
        await context.Response.WriteAsync($"Endpoint:{endpoint.DisplayName}\n");
    }
    await next(context);
});

app.UseEndpoints(endpoints =>
{
    //ADD YOUR END POINTS
    /*endpoints.Map("map1", async (context) =>
    {
        await context.Response.WriteAsync("In Map 1");
    });
    endpoints.Map("map2", async (context) =>
    {
        await context.Response.WriteAsync("In Map 2");
    });
    */
    //eg: files/data.txt
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? fileName=Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In files - {fileName} - {extension}");
    });
    //eg: employee/profile/dimitar
    endpoints.Map("employee/profile/{employeeName:length(3,8):alpha=dimitar}", async context =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeeName"]);
        await context.Response.WriteAsync($"In Employee profile - {employeeName}");
    });
    //eg: products/details/id
    endpoints.Map("products/details/{id:int:range(1,1000)?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"Products details - {id}");
        }
        else
        {
            await context.Response.WriteAsync($"Products details - id is not supplied");
        }
    });
    //eg: daily-digest-report/{reportdate}
    endpoints.Map("daily-digest-report/{reportdate:datetime}", async context =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"In daily-dogest-report - {reportDate}");
    });
    //eg: cities/cityid 
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"]));
        await context.Response.WriteAsync($"City information - {cityId}");
    });
    //eg: sales-report/2030/apr WITHOUT CUSTOM CONSTRAINT
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"Sales information - {year} - {month}");
    });
    //eg: sales-report/2030/apr WITH CUSTOM CONSTRAINT
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"Sales information - {year} - {month}");
    });
    //eg: sales-report/2024/jan this is more specific than the one above 
    endpoints.Map("sales-report/2024/jan", async context =>
    {
        await context.Response.WriteAsync($"Sales information exclusively for 2024 - jan");
    });
});
//default middleware
app.Run(async context =>
{
    await context.Response.WriteAsync($"No route match at{context.Request.Path}");
});
app.Run();
