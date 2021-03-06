using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddHttpClient("api")
            //   .AddHttpMessageHandler(sp =>
            //   {
            //       var handler = sp.GetService<AuthorizationMessageHandler>()
            //           .ConfigureHandler(
            //               authorizedUrls: new[] { "https://localhost:44324" },
            //               scopes: new[] { "PCBuilder.API" });
            //       return handler;
            //   });

            //builder.Services.AddScoped(
            //    sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));




            builder.Services.AddOidcAuthentication(options =>
            {
                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth
                builder.Configuration.Bind("oidc", options.ProviderOptions);
                options.UserOptions.RoleClaim = "role";

            });




            builder.Services.AddMudBlazorDialog();
            builder.Services.AddMudBlazorSnackbar(config =>
            {
                config.PositionClass = Defaults.Classes.Position.BottomCenter;

                config.PreventDuplicates = false;
                config.NewestOnTop = false;
                config.ShowCloseIcon = true;
                config.VisibleStateDuration = 3000;
                config.HideTransitionDuration = 500;
                config.ShowTransitionDuration = 500;
                config.SnackbarVariant = Variant.Outlined;
            });
            builder.Services.AddMudBlazorResizeListener();


            

            await builder.Build().RunAsync();
        }
    }
}
