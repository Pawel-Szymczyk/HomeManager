using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Newtonsoft.Json;

namespace HomeManager.Areas.HomeBudget.Controllers
{
    [Area("HomeBudget")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }


        //public async Task<IActionResult> Index()
        //{
        //    // retireve access token
        //    var serverClient = this._httpClientFactory.CreateClient();

        //    var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:44394/"); // server url

        //    var tokenResponse = await serverClient.RequestClientCredentialsTokenAsync(
        //        new ClientCredentialsTokenRequest
        //        {
        //            Address = discoveryDocument.TokenEndpoint,
        //            ClientId = "client_id",
        //            ClientSecret = "client_secret",

        //            Scope = "HomeBudget.API"
        //        });

        //    // retrieve secret data
        //    var apiClient = _httpClientFactory.CreateClient();

        //    apiClient.SetBearerToken(tokenResponse.AccessToken);

        //    var response = await apiClient.GetAsync("https://localhost:44385/secret");  // api url

        //    var content = await response.Content.ReadAsStringAsync();

        //    return Ok(new 
        //    {
        //        access_token = tokenResponse.AccessToken,
        //        message = content,
        //    });
        //}


        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Secret()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");


            var claims = User.Claims.ToList();
            var _accessToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            var _idToken = new JwtSecurityTokenHandler().ReadJwtToken(idToken);

            var result = await GetSecret(accessToken);

            await RefreshAccessToken();

            return View();
        }

        public IActionResult Logout()
        {
            return SignOut("Cookie", "oidc");
        }

        public async Task<string> GetSecret(string accessToken)
        {
            // retrieve secret data
            var apiClient = _httpClientFactory.CreateClient();

            apiClient.SetBearerToken(accessToken);

            var response = await apiClient.GetAsync("https://localhost:44385/secret");  // api url

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }


        private async Task RefreshAccessToken()
        {
            var serverClient = _httpClientFactory.CreateClient();
            // discover endpoint
            var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:44394/"); // server url

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
            var refreshTokenClient = _httpClientFactory.CreateClient();

            var tokenResponse = await refreshTokenClient.RequestRefreshTokenAsync(
                new RefreshTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                RefreshToken = refreshToken,
                ClientId = "client_id",
                ClientSecret = "client_secret",
            }); 

            var authInfo = await HttpContext.AuthenticateAsync("Cookie");

            // reset/refresh tokens 
            authInfo.Properties.UpdateTokenValue("access_token", tokenResponse.AccessToken);
            authInfo.Properties.UpdateTokenValue("id_token", tokenResponse.IdentityToken);
            authInfo.Properties.UpdateTokenValue("refresh_token", tokenResponse.RefreshToken);


            await HttpContext.SignInAsync("Cookie", authInfo.Principal, authInfo.Properties);

            // validate tokens
            var accessTokenDifferent = !accessToken.Equals(tokenResponse.AccessToken);
            var identityTokenDifferent = !idToken.Equals(tokenResponse.IdentityToken);
            var refreshTokenDifferent = !refreshToken.Equals(tokenResponse.RefreshToken);

            // do sth here if refresh failed...
        }

    }
}