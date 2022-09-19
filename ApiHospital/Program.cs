using ApiHospital;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
var app = builder.Build();

startup.Configure(app, app.Environment);

//app.MapControllerRoute(
//    name: "intConstraint",
//    pattern: "{controller=Home}/{action=Index}/{id:int}");
app.Run();