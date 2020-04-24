using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.EntityFramework;
using BethanyPieShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BethanyPieShop
{
    public class Startup
    {
        public IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppBethyDbContext>(options =>
            options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            // services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppBethyDbContext>();
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppBethyDbContext>();
            services.AddScoped<IFeedbackData, SqlFeedbackData>();
            services.AddScoped<ICategoryData, SqlCategoryData>();
            services.AddScoped<IPieData, SqlPieData>();
            services.AddScoped<ShoppingCart>(sp=>ShoppingCart.GetCart(sp));
            services.AddScoped<IOrderData ,SqlOrderData >();
            services.AddHttpContextAccessor();
            services.AddSession();
            //services.AddScoped<IPieData, ClsMockPieRepository>(); // This will create new object based upon per http request and it will alive as oon as request is active .
            //services.AddScoped<ICategoryData, ClsMockCategoryRepository>();
            //services.AddSingleton() -  basically this will create single instance of the object throught the Application and resuse  the singelton instance.
            //services.AddTransient() - It will give everytime new instance which you ask for that.
            services.AddMvc(); // It is tell that application has to follow MVC Pattern .
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection(); //If we want to run our application on https we need to configute usehttps middle ware .
            app.UseStaticFiles();// This middle ware allow us to server static files and javascripts  and CSS files and so on.
            app.UseSession();
            app.UseAuthentication();
            
           
           // app.UseMvcWithDefaultRoute(); //This middleware basically enable the MVC behaviour .

            //This below Route Section will enable Routeing patten to the MVC 
            app.UseMvc(configRoute =>
            {
                configRoute.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                
            });




        }
    }
}
