using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Security;
using WEBProjekat2025.Data;
using WEBProjekat2025.Data.Cart;
using WEBProjekat2025.Data.Services;
using WEBProjekat2025.Data.ViewModels;
using WEBProjekat2025.Models;
using WEBProjekat2025.NewFolder2;

namespace WEBProjekat2025
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get;  }

        
        public void ConfigureServices(IServiceCollection services)
        {
            // Registracija DbContext-a 
            services.AddDbContext<appDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            // Registracija 

            services.AddScoped<AppDbInitializer>();
            services.AddScoped<IProizvodjaciService,ProizvodjaciService>();
            services.AddScoped<IDiskontiService, DiskontiService> ();
            services.AddScoped<IPiceService, PiceService>();
            services.AddScoped<IOrdersService, OrdersService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            services.AddSession();

            services.AddControllersWithViews();
            services.AddScoped<IAromeService, AromeService>();

            
            services.AddControllersWithViews();

            
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<appDbContext>();
            services.AddMemoryCache();
            services.AddSession();
            
            //Kolacici za autentifikaciju 
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });


            //MVC
            services.AddControllersWithViews();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbInitializer appDbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            
            appDbInitializer.Seed(app);
            AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
        }
    }
}

