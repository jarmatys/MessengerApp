using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApp.Infrastructure;
using MessengerApp.Models.Account;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MessengerApp
{
    public class Startup
    {
        // Pobieranie pliku konfiguracyjnego 
        public IConfiguration Configuration { get; }
        public Startup()
        {
            var config = new ConfigurationBuilder();

            config.AddJsonFile("appsettings.json");
            config.AddEnvironmentVariables("APP_");

            Configuration = config.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            // ��czenie z baz� danych
            services.AddDbContext<EfContext>(builder =>
            {
                builder.UseSqlServer(Configuration["Database:ConnectionString"]);
            });

            // Wstrzykiwanie zale�no�ci o identifykacji u�ytkownik�w
            services.AddIdentity<User, IdentityRole>(options =>
            {
                // Opcje dotycz�ce has�a
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

            }).AddEntityFrameworkStores<EfContext>();

            // Dodajemy do kontenera zale�no�ci menad�era wiadomo�ci
            services.AddScoped<MessengerManager>();
            services.AddScoped<ChannelManager>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
