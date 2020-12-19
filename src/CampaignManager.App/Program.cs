using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampaignManager.App.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CampaignManager.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            PrepareDatabaseAsync(host).Wait();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static async Task PrepareDatabaseAsync(IHost host)
        {
            using(var scope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userDbContext = scope.ServiceProvider.GetService<UserDbContext>();
                if(await userDbContext.Database.GetService<IRelationalDatabaseCreator>().ExistsAsync() == false)
                {
                    await userDbContext.Database.MigrateAsync();
                }
                else
                {
                    var migrations = await userDbContext.Database.GetPendingMigrationsAsync();
                    if(migrations.ToList().Count > 0)
                    {
                        await userDbContext.Database.MigrateAsync();
                    }
                }

                var appDbContext = scope.ServiceProvider.GetService<AppDbContext>();
                if(await appDbContext.Database.GetService<IRelationalDatabaseCreator>().ExistsAsync() == false)
                {
                    await appDbContext.Database.MigrateAsync();
                }
                else
                {
                    var migrations = await appDbContext.Database.GetPendingMigrationsAsync();
                    if(migrations.ToList().Count > 0)
                    {
                        await appDbContext.Database.MigrateAsync();
                    }
                }
            }
        }
    }
}
