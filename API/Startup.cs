using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands;
using Application.Commands.CityCommands;
using Application.Commands.LocaleCommands;
using Application.Commands.LocaleMenuCommands;
using Application.Commands.LocalePhotoCommands;
using Application.Commands.LocaleTableCommands;
using Application.Commands.LocaleTypeCommands;
using Application.Commands.ReservationCommands;
using Application.Commands.ReviewCommands;
using Application.Commands.ReviewPhotoCommands;
using Application.Commands.RoleCommands;
using Application.Commands.UserCommands;
using Application.Helpers;
using Application.Intefaces;
using EfCommands;
using EfCommands.EfCityCommands;
using EfCommands.EfLocaleCommands;
using EfCommands.EfLocaleMenuCommands;
using EfCommands.EfLocalePhotoCommands;
using EfCommands.EfLocaleTableComands;
using EfCommands.EfLocaleTypeCommands;
using EfCommands.EfReservationCommands;
using EfCommands.EfReviewCommands;
using EfCommands.EfReviewPhotoCommands;
using EfCommands.EfRoleCommands;
using EfCommands.EfUserCommands;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<EfContext>();
            //role
            services.AddTransient<IGetRoleCommand, EfGetRoleCommand>();
            services.AddTransient<IGetRolesCommand, EfGetRolesCommand>();
            services.AddTransient<IAddRoleCommand, EfAddRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
            services.AddTransient<IEditRoleCommand, EfEditRoleCommand>();
            //city
            services.AddTransient<IAddCityCommand, EfAddCityCommand>();
            services.AddTransient<IGetCitiesCommand, EfGetCitiesCommand>();
            services.AddTransient<IDeleteCityCommand, EfDeleteCityCommand>();
            services.AddTransient<IGetCityCommand, EfGetCityCommand>();
            services.AddTransient<IEditCityCommand, EfEditCityCommand>();
            //user
            services.AddTransient<IGetUsersCommand, EfGetUsersCommand>();
            services.AddTransient<IGetUserCommand, EfGetUserCommand>();
            services.AddTransient<IAddUserCommand, EfAddUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<ILoginUserCommand, EfLoginUserCommand>();
            //localeType
            services.AddTransient<IAddLocaleTypeCommand, EfAddLocaleTypeCommand>();
            services.AddTransient<IGetLocaleTypesCommand, EfGetLocaleTypesCommand>();
            services.AddTransient<IGetLocaleTypeCommand, EfGetLocaleTypeCommand>();
            services.AddTransient<IEditLocaleTypeCommand, EfEditLocaleTypeCommand>();
            services.AddTransient<IDeleteLocaleTypeCommand, EfDeleteLocaleTypeCommand>();
            //locale
            services.AddTransient<IAddLocaleCommand, EfAddLocaleCommand>();
            services.AddTransient<IDeleteLocaleCommand, EfDeleteLocaleCommand>();
            services.AddTransient<IEditLocaleCommand, EfEditLocaleCommand>();
            services.AddTransient<IGetLocalesCommand, EfGetLocalesCommand>();
            services.AddTransient<IGetLocaleCommand, EfGetLocaleCommand>();
            //localeTable
            services.AddTransient<IAddLocaleTableCommand, EfAddLocaleTableCommand>();
            services.AddTransient<IGetLocaleTablesCommand, EfGetLocaleTablesCommand>();
            services.AddTransient<IGetLocaleTableCommand, EfGetLocaleTableCommand>();
            services.AddTransient<IEditLocaleTableCommand, EfEditLocaleTableCommand>();
            services.AddTransient<IDeleteLocaleTableCommand, EfDeleteLocaleTableCommand>();
            //reservation
            services.AddTransient<IAddReservationCommand, EfAddReservaionCommand>();
            services.AddTransient<IEditReservationCommand, EfEditReservationCommand>();
            services.AddTransient<IDeleteReservationCommand, EfDeleteReservationCommand>();
            services.AddTransient<IGetReservationCommand, EfGetReservationCommand>();
            services.AddTransient<IGetReservationsCommand, EfGetReservationsCommand>();
            //localePhoto
            services.AddTransient<IAddLocalePhotoCommand, EfAddLocalePhotoCommand>();
            services.AddTransient<IGetLocalePhotosCommand, EfGetLocalePhotosCommand>();
            services.AddTransient<IGetLocalePhotoCommand, EfGetLocalePhotoCommand>();
            services.AddTransient<IEditLocalePhotoCommand, EfEditLocalePhotoCommand>();
            services.AddTransient<IDeleteLocalePhotoCommand, EfDeleteLocalePhotoCommand>();
            //localeMenu
            services.AddTransient<IAddLocaleMenuCommand, EfAddLocaleMenuCommand>();
            services.AddTransient<IGetLocaleMenusCommand, EfGetLocaleMenusCommand>();
            services.AddTransient<IGetLocaleMenuCommand, EfGetLocaleMenuCommand>();
            services.AddTransient<IEditLocaleMenuCommand, EfEditLocaleMenuCommand>();
            services.AddTransient<IDeleteLocaleMenuCommand, EfDeleteLocaleMenuCommand>();
            //review
            services.AddTransient<IAddReviewCommand, EfAddReviewCommand>();
            services.AddTransient<IEditReviewCommand, EfEditReviewCommand>();
            services.AddTransient<IDeleteReviewCommand, EfDeleteReviewCommand>();
            services.AddTransient<IGetReviewCommand, EfGetReviewCommand>();
            services.AddTransient<IGetReviewsCommand, EfGetReviewsCommand>();
            //reviewPhoto
            services.AddTransient<IAddReviewPhotoCommand, EfAddReviewPhotoCommand>();
            services.AddTransient<IGetReviewPhotoCommand, EfGetReviewPhotoCommand>();
            services.AddTransient<IGetReviewPhotosCommand, EfGetReviewPhotosCommand>();
            services.AddTransient<IEditReviewPhotoCommand, EfEditReviewPhotoCommand>();
            services.AddTransient<IDeleteReviewPhotoCommand, EfDeleteReviewPhotoCommand>();



            //Email
            var section = Configuration.GetSection("Email");

            var sender =
                new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["fromaddress"], section["password"]);

            services.AddSingleton<IEmailSender>(sender);


            //Encryption
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            var key = Configuration.GetSection("Encryption")["key"];

            var enc = new Encryption(key);
            services.AddSingleton(enc);


            services.AddTransient(s => {
                var http = s.GetRequiredService<IHttpContextAccessor>();
                var value = http.HttpContext.Request.Headers["Authorization"].ToString();
                var encryption = s.GetRequiredService<Encryption>();

                try
                {
                    var decodedString = encryption.DecryptString(value);
                    decodedString = decodedString.Replace("\f", "");
                    var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);
                    user.IsLogged = true;
                    return user;
                }
                catch (Exception)
                {
                    return new LoggedUser
                    {
                        IsLogged = false
                    };
                }
            });

            //Swegger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ReserveYourSpot", Version = "v1" });
            });


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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();


            //Swegger
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            

        }
    }
}
