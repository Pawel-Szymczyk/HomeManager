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

namespace HomeBudget.API
{
    public class Startup
    {
        /// <summary>
        /// Server URL used when making OpenIdConnect call.
        /// </summary>
        private string authority = "https://localhost:44394/"; 

        /// <summary>
        /// Valid audience value for any received OpenIdConnect token.
        /// </summary>
        private string audience = "homeBudget.api";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
                
        public void ConfigureServices(IServiceCollection services)
        {
            
            // TODO: set up policies here based on claims and user roles 

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", config => {
                    config.Authority = this.authority;
                    config.Audience = this.audience;
                });

  
            services.AddControllers();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
