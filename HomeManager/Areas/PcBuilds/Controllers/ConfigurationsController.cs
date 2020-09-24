using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        private readonly string apiComponentsController = "components";

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

        // GET: Configurations/Create
        public IActionResult Create()
        {
            // get list of processors


            return this.View();
        }

        // POST: Configurations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Configuration model)
        {
            try
            {
                //Configuration configuration = new Configuration
                //{
                //    Id = "",
                //    CPUWatercooler = "",
                //    CreatedDate = "",
                //    Description = "",
                //    Fan = "",
                //    GraphicsCard ="",
                //    HardDrive = "",
                //    ModifiedDate = "",
                //    Motherboard = "",
                //    Other ="",
                //    PCCase = "",
                //    PowerSupply ="",
                //    Processor ="",
                //    RAM = "",
                //    TotalPrice = ""
                //}

                var configuration = new {
                    cpuWatercoolerId = model.CPUWatercooler.Id,
                    description = model.Description,
                    fanId = model.Fan.Id,
                    graphicsCardId = model.GraphicsCard.Id,
                    hardDrivedId = model.HardDrive.Id,
                    motherboardId = model.Motherboard.Id,
                    otherId = model.Other.Id,
                    pcCaseId = model.PCCase.Id,
                    powerSupplyId = model.PowerSupply.Id,
                    processorId = model.Processor.Id,
                    ramId = model.RAM.Id,
                    totalPrice = model.TotalPrice
                };

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(configuration), Encoding.UTF8, "application/json");

                    using (HttpResponseMessage response = await httpClient.PostAsync(string.Format("{0}/{1}", this.apiBaseUrl, this.apiController), content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //receivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                    }
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch
            {
                return this.View();
            }
        }




    }
}