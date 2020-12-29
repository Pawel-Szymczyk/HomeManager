using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Repositories;
using System;
using System.IO;
using System.Reflection;

namespace PCBuilder.Service.API
{
    public class Startup
    {
        /// <summary>
        /// Server URL used when making OpenIdConnect call.
        /// </summary>
        private string authority = "https://localhost:5015/";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<PCBuilderContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("PCBuildDB")));

            services.AddScoped<PCBuildRepository>();
            services.AddScoped<ProcessorRepository>();
            services.AddScoped<MotherboardRepository>();
            services.AddScoped<RAMRepository>();
            services.AddScoped<GraphicsCardRepository>();
            services.AddScoped<HardDriveRepository>();
            services.AddScoped<CPUWatercoolerRepository>();
            services.AddScoped<FanRepository>();
            services.AddScoped<PCCaseRepository>();
            services.AddScoped<PowerSupplyRepository>();
            services.AddScoped<OtherRepository>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PC Builder Microservice API",
                    Description = "PC Builder Web API showing off pc builds microservice functionality and features."
                });

                // Set the comments path for the Swagger JSON and UI.
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", config =>
                {
                    config.Authority = this.authority;
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "PCBuilder.API");
                });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PC builder API V1");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(policy =>
                 policy.WithOrigins("http://localhost:5005", "https://localhost:5015")
                 .AllowAnyMethod()
                 .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
                 .AllowCredentials());




            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers().RequireAuthorization("ApiScope");
                endpoints.MapControllers();
            });
        }
    }
}
