using Assignment5.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Assignment5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<FavBooksContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:FavoriteBooksConnection"]);
            });

            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddScoped<IOrderRepository, EFOrderRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddServerSideBlazor();

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlite(
                    Configuration["ConnectionStrings:IdentityConnection"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            //services.AddDbContext<SemiAdminDbContext>(options =>
            //    options.UseSqlite(
            //        Configuration["ConnectionStrings:SemiAdminConnection"]));

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<SemiAdminDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Make it so the user can type in something in the URL to navigate around the pages.
                endpoints.MapControllerRoute("catpage",
                   "{category}/{pageNum:int}",
                   new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("pageNum",
                    "{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                endpoints.MapControllerRoute(
                    "pagination",
                    "P{pageNum}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

            //Ensures data is populated
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
            //SemiAdminSeedData.EnsurePopulated(app);
            
        }
    }
}
