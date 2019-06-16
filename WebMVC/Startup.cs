using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.CityCommands;
using Application.Commands.LocaleCommands;
using Application.Commands.LocaleTableCommands;
using Application.Commands.LocaleTypeCommands;
using Application.Commands.UserCommands;
using EfCommands;
using EfCommands.EfCityCommands;
using EfCommands.EfLocaleCommands;
using EfCommands.EfLocaleTableComands;
using EfCommands.EfLocaleTypeCommands;
using EfCommands.EfUserCommands;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<EfContext>();
            services.AddTransient<IGetLocalesCommand, EfGetLocalesCommand>();
            services.AddTransient<IGetLocaleCommand, EfGetLocaleCommand>();
            services.AddTransient<IGetLocaleWithIdsCommand, EfGetLocaleWithIdsCommand>();
            services.AddTransient<IAddLocaleCommand, EfAddLocaleCommand>();
            services.AddTransient<IEditLocaleCommand, EfEditLocaleCommand>();
            services.AddTransient<IDeleteLocaleCommand, EfDeleteLocaleCommand>();

            services.AddTransient<IGetLocaleTablesCommand, EfGetLocaleTablesCommand>();
            services.AddTransient<IGetLocaleTableCommand, EfGetLocaleTableCommand>();
            services.AddTransient<IGetLocaleTableWitIdsCommand, EfGetLocaleTableWithIdsCommand>();
            services.AddTransient<IAddLocaleTableCommand, EfAddLocaleTableCommand>();
            services.AddTransient<IEditLocaleTableCommand, EfEditLocaleTableCommand>();
            services.AddTransient<IDeleteLocaleTableCommand, EfDeleteLocaleTableCommand>();


            services.AddTransient<IGetCitiesCommand, EfGetCitiesCommand>();
            services.AddTransient<IGetLocaleTypesCommand, EfGetLocaleTypesCommand>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
