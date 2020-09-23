using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HomeManager.Areas.PcBuilds.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HomeManager.Areas.PcBuilds.Controllers
{
    [Area("PcBuilds")]
    public class ConfigurationsController : Controller
    {
        private readonly ILogger<ConfigurationsController> _logger;
        private readonly IConfiguration _configure;
        private readonly string apiBaseUrl;
        private readonly string apiController = "pcbuilds";

        public ConfigurationsController(ILogger<ConfigurationsController> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configure = configuration;

            this.apiBaseUrl = this._configure.GetValue<string>("WebAPIBaseUrl");
        }

        // GET: Configurations
        public async Task<IActionResult> Index()
        {

            var configurationsList = new List<Configuration>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}", this.apiBaseUrl, this.apiController)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    configurationsList = JsonConvert.DeserializeObject<List<Configuration>>(apiResponse);
                }
            }


            return this.View(configurationsList);
        }

        // GET: Configurations/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var configuration = new Configuration();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    configuration = JsonConvert.DeserializeObject<Configuration>(apiResponse);
                }
            }

            return this.View(configuration);
        }
    }
}