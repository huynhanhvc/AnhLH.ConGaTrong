using System;
using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace AnhLH.ConGaTrong;

public class Program
{
    public static int Main(string[] args)
    {
        //            Log.Logger = new LoggerConfiguration()
        //#if DEBUG
        //                .MinimumLevel.Debug()
        //#else
        //                .MinimumLevel.Information()
        //#endif
        //                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        //                .Enrich.FromLogContext()
        //                .WriteTo.Async(c => c.File("Logs/logs.txt"))
        //#if DEBUG
        //                .WriteTo.Async(c => c.Console())
        //#endif
        //                .CreateLogger();
        var configBuilderOpts = new AbpConfigurationBuilderOptions();
        configBuilderOpts.EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var config = ConfigurationHelper.BuildConfiguration(configBuilderOpts);
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(config)
            .CreateLogger();

        try
        {
            Log.Information("Starting web host.");
            CreateHostBuilder(args).Build().Run();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
    
    internal static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .AddAppSettingsSecretsJson()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseAutofac()
            .UseAllElasticApm()
            .UseSerilog();
}
