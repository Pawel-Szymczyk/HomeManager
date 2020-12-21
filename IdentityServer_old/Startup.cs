using AutoMapper;
using IdentityServer.Data;
using IdentityServer.Models;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;

namespace IdentityServer
{
    // Registration process comes from: 
    // - https://code-maze.com/identity-asp-net-core-project/
    // - https://code-maze.com/user-registration-aspnet-core-identity/

    public class Startup
    {
        private readonly IConfiguration _config;

        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration config, IWebHostEnvironment environment)
        {
            this._config = config;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(config =>
            //{
            //    //config.UseSqlServer(connectionString);
            //    config.UseInMemoryDatabase("Memory");
            //});

            ////Add identity registers the services
            //services.AddIdentity<IdentityUser, IdentityRole>(config =>
            //{
            //    config.Password.RequiredLength = 4;
            //    config.Password.RequireDigit = false;
            //    config.Password.RequireNonAlphanumeric = false;
            //    config.Password.RequireUppercase = false;
            //})
            //    .AddEntityFrameworkStores<AppDbContext>()
            //    .AddDefaultTokenProviders();


            //services.ConfigureApplicationCookie(config =>
            //{
            //    config.Cookie.Name = "IdentityServer.Cookie";
            //    config.LoginPath = "/Auth/Login";
            //    //config.LogoutPath = "/Auth/Logout";
            //});


            services.AddAutoMapper(typeof(Startup));


            string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            string connectionString = this._config.GetConnectionString("DefaultConnection");


            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddIdentityServer()
                //.AddTestUsers(TestUsers.Users)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddDeveloperSigningCredential();


            //var builder = services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryIdentityResources(Config.IdentityResources)
            //    .AddInMemoryApiScopes(Config.ApiScopes)
            //    .AddInMemoryClients(Config.Clients)
            //    .AddTestUsers(TestUsers.Users);



            //services.AddSingleton<ICorsPolicyService>((container) =>
            //{
            //    var logger = container.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
            //    return new DefaultCorsPolicyService(logger)
            //    {
            //        AllowedOrigins = { "https://localhost:44307" }
            //    };
            //});


            //services.AddIdentityServer(config =>
            //{
            //    //config.EmitStaticAudienceClaim = true;
            //})
            //    .AddAspNetIdentity<IdentityUser>()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryIdentityResources(Config.GetIdentityResources())
            //    .AddInMemoryApiScopes(Config.GetScopes())
            //    .AddInMemoryApiResources(Config.GetApiResources())
            //    .AddInMemoryClients(Config.GetClients());

            services.AddControllersWithViews();
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.Clients)
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in Config.IdentityResources)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var resource in Config.ApiScopes)
                    {
                        context.ApiScopes.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Note: 
            // The above InitializeDatabase helper API is convenient to seed the database, 
            // but this approach is not ideal to leave in to execute each time the application runs.
            // Once your database is populated, consider removing the call to the API.
            InitializeDatabase(app);


            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

        }



    }
}
