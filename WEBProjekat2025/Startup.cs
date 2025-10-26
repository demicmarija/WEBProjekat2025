using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Security;
using WEBProjekat2025.Data;
using WEBProjekat2025.Data.Cart;
using WEBProjekat2025.Data.Services;
using WEBProjekat2025.Data.ViewModels;
using WEBProjekat2025.NewFolder2;

namespace WEBProjekat2025
{
    public class Startup
    {
        // Konstruktor za čitanje konfiguracije (npr. connection string iz appsettings.json)
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get;  }

        // 1️⃣ Ovde se registruju svi servisi (uključujući DbContext i AppDbInitializer)
        public void ConfigureServices(IServiceCollection services)
        {
            // Registracija DbContext-a (prilagodi ime connection stringa ako nije isto)
            services.AddDbContext<appDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            // Registracija AppDbInitializer klase
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

            // Dodavanje MVC servisa (za kontrolere i view-ove)
            services.AddControllersWithViews();
        }

        // 2️⃣ Ovde se konfiguriše HTTP pipeline i pokreće inicijalizacija baze
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

            app.UseAuthorization();

            // Ruta za kontrolere (default: Home/Index)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // 🔹 Pokretanje metode za inicijalizaciju baze
            appDbInitializer.Seed(app);
        }
    }
}

