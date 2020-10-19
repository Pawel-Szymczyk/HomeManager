using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HomeManager
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", config => {
            //        config.Authority = "https://localhost:44394/"; // server url
            //        config.Audience = "HomeManager";
            //    });

            services.AddAuthentication(config => {
                config.DefaultScheme = "Cookie";
                config.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookie")
                .AddOpenIdConnect("oidc", config => {
                    config.Authority = "https://localhost:44394/"; // server url
                    config.ClientId = "client_id";
                    config.ClientSecret = "client_secret";
                    config.SaveTokens = true;
                    config.ResponseType = "code";
                    config.SignedOutCallbackPath = "/Home/Index";

                    // configure cookie claim mapping
                    //config.ClaimActions.MapUniqueJsonKey("RawCoding.Grandma", "rc.grandma");
                    config.ClaimActions.MapUniqueJsonKey("RawCoding.Role", "role");

                    // two trips to load claims in to the cookie
                    // but the id token is smaller !
                    config.GetClaimsFromUserInfoEndpoint = true;

                    // configure scope
                    // clear and add options allow you to remove all scopes 
                    // and manually add only scopes you need
                    //config.Scope.Clear();
                    //config.Scope.Add("openid");
                    config.Scope.Add("offline_access");
                    //config.Scope.Add("rc.scope");
                    //config.Scope.Add("HomeBudget.API");

                    config.Scope.Add("homeBudget.api.read");
                    config.Scope.Add("homeBudget.api.write");
                 

                });

            // add http client to be able to request the token and then use this http client to 
            // call the HomeBudget.API
            services.AddHttpClient();

            services.AddControllersWithViews();
        }


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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
