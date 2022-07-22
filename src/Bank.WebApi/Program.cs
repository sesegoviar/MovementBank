using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.ApplicationCore;
using Store.Infrastructure;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Store.WebApi {

    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = CreateHostBuilder(args).Build();                        

            await builder.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });        
    }    
}