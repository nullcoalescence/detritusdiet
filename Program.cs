using System;
using System.IO;
using detritusdiet.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace detritusdiet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add appsettings.json
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration config = configBuilder.Build();

            builder.Services.Configure<IConfiguration>(config);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Data access
            var connectionString = builder.Configuration.GetConnectionString("AppSqlServerDb");
            // @TODO - proper secrets management:
            // Right now, just use dotnet-secrets locally for dev
            var username = builder.Configuration["DetritusDietSecrets:DbUser"];
            var password = builder.Configuration["DetritusDietSecrets:DbPass"];

            connectionString += $";user id={username};password={password}";

            
            builder.Services.AddDbContext<DietContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}