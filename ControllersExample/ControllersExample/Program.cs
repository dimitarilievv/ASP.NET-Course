using ControllersExample.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); //adds all the controllers as services

var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();
app.Run();
