using Microsoft.EntityFrameworkCore;
using ToDoList.Domain;
using NLog;
using NLog.Web;
using System;


var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddLogging(conf =>
    {
        conf.ClearProviders();
        conf.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    });
    builder.Host.UseNLog();
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("pstgr"));
    });


    var app = builder.Build();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Task}/{action=Index}/{id?}");
    app.Run();

}
catch (Exception ex)
{
    logger.Error(ex,ex.Message, "Остановка программы из-за ошибки");
    throw;
}
finally
{
    
    LogManager.Shutdown();
}
