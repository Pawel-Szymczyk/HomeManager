using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

namespace Test.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Server URL used when making OpenIdConnect call.
        /// </summary>
        private string authority = "https://localhost:5001/";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", config =>
            //    {
            //        config.Authority = this.authority;

            //        config.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateAudience = false
            //        };
            //    });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ApiScope", policy =>
            //    {
            //        policy.RequireAuthenticatedUser();
            //        policy.RequireClaim("scope", "Test.API");
            //    });
            //});

            // TODO: fix CORS
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "Open",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(policy =>
            //policy.WithOrigins("https://localhost:44332/")
            //.AllowAnyMethod()
            //.WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
            //.AllowCredentials());
            app.UseCors("Open");


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                    //.RequireAuthorization("ApiScope");
            });
        }
    }
}
