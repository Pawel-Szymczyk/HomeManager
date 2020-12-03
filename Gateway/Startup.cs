using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;

namespace Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            //var authenticationProviderKey = "OcelotKey";
            //Action<IdentityServerAuthenticationOptions> options = o =>
            //{
            //    o.Authority = "https://localhost:44382";    // server
            //    o.ApiName = "api";
            //    o.SupportedTokens = SupportedTokens.Both;
            //    o.ApiSecret = "secret";
            //};

            //services.AddAuthentication()
            //    .AddIdentityServerAuthentication(authenticationProviderKey, options);

            //var identityBuilder = services.AddAuthentication();
            //identityBuilder.AddIdentityServerAuthentication("CatalogAPIKey", options =>
            //{
            //    options.Authority = "{IDM_SERVER_URL}";
            //    options.RequireHttpsMetadata = false;
            //    options.ApiName = "{RESOURCE_API_NAME}";
            //    options.ApiSecret = "{RESOIRCE_API_Secret}";
            //    options.SupportedTokens = SupportedTokens.Jwt;
            //});

            var authenticationProviderKey = "OcelotKey";
            Action<IdentityServerAuthenticationOptions> options = o =>
            {
                o.Authority = "https://localhost:44382";    // server
                o.RequireHttpsMetadata = false;
                o.ApiName = "{RESOURCE_API_NAME}";
                o.ApiSecret = "{RESOIRCE_API_Secret}";
                o.SupportedTokens = SupportedTokens.Jwt;
            };

            services.AddAuthentication()
                .AddIdentityServerAuthentication(authenticationProviderKey, options);

            services.AddOcelot();

        }
        
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // ocelot
            await app.UseOcelot();
        }
    }
}
