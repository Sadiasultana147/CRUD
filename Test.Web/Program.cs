using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Reflection;
using Test.Application;
using Test.Infrastructure;
using Test.Persistance;

namespace Test.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Serilog Config
            builder.Host.UseSerilog((ctx, lc) => lc
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(builder.Configuration));
            try
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                var migrationAssembly = Assembly.GetExecutingAssembly().FullName;

                //Autofac Config

                builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
                builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
                {
                    //Dependency Injection
                    containerBuilder.RegisterModule(new ApplicationModule());
                    containerBuilder.RegisterModule(new InfrastructureModule());
                    containerBuilder.RegisterModule(new PersistenceModule(connectionString,
                    migrationAssembly));
                    containerBuilder.RegisterModule(new WebModule());
                });
                

                // Add services to the container.
                builder.Services.AddControllersWithViews();

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
                Log.Information("Application Starting...");
                app.Run();
            }

            catch (Exception ex)
            {
                Log.Fatal(ex, "Failed to start application.");
            }
            finally
            {
                Log.CloseAndFlush();
            }


        }
    }
}