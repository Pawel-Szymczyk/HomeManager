// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using AutoMapper;
using IdentityServer.Quickstart;
using IdentityServer.Quickstart.Data;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using IdentityServer.Services;

namespace IdentityServer
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public IWebHostEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            string connectionString = this._configuration.GetConnectionString("DefaultConnection");

            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(Startup));

            // --------------------------------------------------------------------------------------
            // User Registration
            // 
            services.AddDbContext<ServerDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                // todo: remove them
                options.Password.RequiredLength = 4;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ServerDbContext>();


            // --------------------------------------------------------------------------------------
            // User Authentication
            //
            services.AddIdentityServer()
                .AddAspNetIdentity<User>()
                .AddProfileService<CustomProfileService>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationAssembly));
                })
                .AddDeveloperSigningCredential();

        }

        //TODO: 
        // The above InitializeDatabase helper API is convenient to seed the database, but this approach is not ideal to leave in to execute each time the application runs.
        // Once your database is populated, consider removing the call to the API.
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

        public void Configure(IApplicationBuilder app)
        {
            // this will do the initial DB population
            //InitializeDatabase(app);


            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
