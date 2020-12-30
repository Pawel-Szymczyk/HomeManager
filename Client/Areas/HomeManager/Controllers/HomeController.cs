using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Client.Models;
using System.Net.Http;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;

namespace Client.Controllers
{
    [Area("HomeManager")]
    //[Authorize]    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        //
        public async Task<IActionResult> Index()
        {
            // Welcome page - quick api test (direct call to api without user interaction - machine to machine )


            // retrieve access token
            var serverClient = _httpClientFactory.CreateClient();
            var disco = await serverClient.GetDiscoveryDocumentAsync("https://localhost:5001/");   // server
            if(disco.IsError)
            {
                // error msg 
                return View(
                    new Test
                    {
                        access_token = "",
                        message = disco.Error
                    });
            }

            var tokenResponse = await serverClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,

                    ClientId = "client",
                    ClientSecret = "secret",
                    Scope = "api1"
                });

            if(tokenResponse.IsError)
            {
                // error msg
                return View(
                    new Test
                    {
                        access_token = "",
                        message = tokenResponse.Error
                    });
            }

            var json = tokenResponse.Json;

            // call api
            var apiClient = _httpClientFactory.CreateClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("https://localhost:44325/api/secret");
            if(!response.IsSuccessStatusCode)
            {
                // error msg
                return View(
                    new Test
                    {
                        access_token = "",
                        message = "API Authorization Error"
                    });
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return View(
                    new Test
                    {
                        access_token = tokenResponse.AccessToken,
                        message = content
                    });
            }


        }

        [Authorize]
        public async Task<IActionResult> Secret()
        {
            // call api here

            // use for external authorization ,e.g. API
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            // use for user identification, e.g. client
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");

            var claims = User.Claims.ToList();
            var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);

            var result = await GetSecret(accessToken);

            var ramResult = await GetRam(accessToken);


            return View(result);
        }


        //private async Task<string> GetSecret(string accessToken)
        private async Task<Test> GetSecret(string accessToken)
        {
            // retrieve secret data
            var apiClient = _httpClientFactory.CreateClient();

            apiClient.SetBearerToken(accessToken);

            var response = await apiClient.GetAsync("https://localhost:44325/api/secret");  // api url

            var content = await response.Content.ReadAsStringAsync();

            
            return new Test
            {
                access_token = accessToken,
                message = content
            };

            //return content;
        }

        private async Task<object> GetRam(string accessToken)
        {
            // retrieve secret data
            var apiClient = _httpClientFactory.CreateClient();
            apiClient.SetBearerToken(accessToken);
            var response = await apiClient.GetAsync("https://localhost:44324/api/v1/rams");
            var content = await response.Content.ReadAsStringAsync();

            return new
            {

            };
        }



        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
