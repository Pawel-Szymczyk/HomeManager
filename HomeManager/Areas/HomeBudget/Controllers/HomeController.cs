using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;

namespace HomeManager.Areas.HomeBudget.Controllers
{
    [Area("HomeBudget")]
    public class HomeController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;

        //public HomeController(IHttpClientFactory httpClientFactory)
        //{
        //    this._httpClientFactory = httpClientFactory;
        //}


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
        public IActionResult Secret()
        {
            return View();
        }


    }
}