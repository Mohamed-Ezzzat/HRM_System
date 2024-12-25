using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM_System.Data;
using HRM_System.Data.Base;
using HRM_System.Models;
using HRM_System.seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HRM_System
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {

                var context = services.GetRequiredService<AppDbContext>();
                await context.Database.MigrateAsync();

                
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await AdminDbSeed.SeedRolesAsync(roleManager);

                var userManager = services.GetRequiredService<UserManager<HRUser>>();
                var usergroup = services.GetRequiredService<IEntityRepository<Usergroupsandpermissions>>();
                await AdminDbSeed.SeedHR_Async(userManager);
                await roleManager.SeedClaimsForHRAdmin();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error occured during applying migration");

            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
