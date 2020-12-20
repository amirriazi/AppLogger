using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace AppLogger
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(Configuration.GetSection("Serilog"))
            //    .CreateLogger();
            //Log.Logger = new LoggerConfiguration()
            //       .Enrich.FromLogContext()
            //       .MinimumLevel.Debug()
            //       .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            //       .WriteTo.MSSqlServer("Server=IDEAPAD330-04;Initial Catalog=ApiLoggerDB;User ID=amirriazi;Password=66177602;",
            //                            tableName: "Log")

            //       .CreateLogger();
            ;
            try
            {
                //Serilog.Debugging.SelfLog.Enable(Console.Error);
                Log.Information("Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
