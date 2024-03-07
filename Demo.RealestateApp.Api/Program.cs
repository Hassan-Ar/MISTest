

using Demo.RealestateApp.Api;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .CreateBootstrapLogger();

//Log.Information("API starting");

var builder = WebApplication.CreateBuilder(args);



//builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
//     .WriteTo.Console()
//     .ReadFrom.Configuration(context.Configuration));


var app = builder
    .
    ConfigureServices()
    .ConfigurePipeline();


//app.UseSerilogRequestLogging();
//await app.ResetDatabaseAsync();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});


app.Run();
