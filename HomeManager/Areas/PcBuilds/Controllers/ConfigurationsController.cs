﻿using HomeManager.Areas.PcBuilds.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Create()
        {
            var components = new Components();

            using (var httpClient = new HttpClient())
            {
                components = await this.ReturnListOfPcComponents(httpClient);
            }

            return this.View(components);
        }

        public async Task<Components> ReturnListOfPcComponents(HttpClient httpClient)
        {
            // References: https://www.newtonsoft.com/json/help/html/ToObjectComplex.htm

            Components components = new Components();

            using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}", this.apiBaseUrl, this.apiComponentsController)))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                var jObject = JObject.Parse(apiResponse);


                var cpuWatercoolers = (JArray)jObject["cpuWatercoolers"];
                IList<CPUWatercooler> cpuWatercoolersList = cpuWatercoolers.ToObject<IList<CPUWatercooler>>();
                components.CPUWatercoolers = new List<CPUWatercooler>(cpuWatercoolersList);

                var fans = (JArray)jObject["fans"];
                IList<Fan> fansList = fans.ToObject<IList<Fan>>();
                components.Fans = new List<Fan>(fansList);

                var graphicsCards = (JArray)jObject["graphicsCards"];
                IList<GraphicsCard> graphicsCardsList = graphicsCards.ToObject<IList<GraphicsCard>>();
                components.GraphicsCards = new List<GraphicsCard>(graphicsCardsList);

                var hardDrives = (JArray)jObject["hardDrives"];
                IList<HardDrive> hardDrivesList = hardDrives.ToObject<IList<HardDrive>>();
                components.HardDrives = new List<HardDrive>(hardDrivesList);

                var motherboards = (JArray)jObject["motherboards"];
                IList<Motherboard> motherboardsList = motherboards.ToObject<IList<Motherboard>>();
                components.Motherboards = new List<Motherboard>(motherboardsList);

                var others = (JArray)jObject["others"];
                IList<Other> othersList = others.ToObject<IList<Other>>();
                components.Others = new List<Other>(othersList);

                var pcCases = (JArray)jObject["pcCases"];
                IList<PCCase> pcCasesList = pcCases.ToObject<IList<PCCase>>();
                components.PCCases = new List<PCCase>(pcCasesList);

                var powerSupplies = (JArray)jObject["powerSupplies"];
                IList<PowerSupply> powerSuppliesList = powerSupplies.ToObject<IList<PowerSupply>>();
                components.PowerSupplies = new List<PowerSupply>(powerSuppliesList);

                var processors = (JArray)jObject["processors"];
                IList<Processor> processorsList = processors.ToObject<IList<Processor>>();
                components.Processors = new List<Processor>(processorsList);

                var rams = (JArray)jObject["rams"];
                IList<RAM> ramsList = rams.ToObject<IList<RAM>>();
                components.RAMs = new List<RAM>(ramsList);


            }

            return components;
        }



        // POST: Configurations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Components model)
        {
            try
            {

                var configuration = new
                {
                    cpuWatercoolerId = model.SelectedCPUWatercoolerId,
                    description = model.Configuration.Description,
                    fanId = model.SelectedFanId,
                    graphicsCardId = model.SelectedGraphicsCardId,
                    hardDrivedId = model.SelectedHardDriveId,
                    motherboardId = model.SelectedMotherboardId,
                    otherId = model.SelectedOtherId,
                    pcCaseId = model.SelectedPCCaseId,
                    powerSupplyId = model.SelectedPowerSupplyId,
                    processorId = model.SelectedProcessorId,
                    ramId = model.SelectedRAMId,
                    totalPrice = model.Configuration.TotalPrice // to do
                };

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(configuration), Encoding.UTF8, "application/json");

                    using (HttpResponseMessage response = await httpClient.PostAsync(string.Format("{0}/{1}", this.apiBaseUrl, this.apiController), content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch
            {
                return this.View();
            }
        }


        // GET: Configurations/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {

            var components = new Components();

            using (var httpClient = new HttpClient())
            {
                components = await this.ReturnListOfPcComponents(httpClient);

                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Configuration>(apiResponse);

                    components.Configuration.Description = result?.Description;
                    components.Configuration.TotalPrice = result.TotalPrice;

                    components.SelectedCPUWatercoolerId = (result.CPUWatercooler != null) ? result.CPUWatercooler.Id.ToString() : string.Empty;
                    components.SelectedFanId = (result.Fan != null) ? result.Fan.Id.ToString() : string.Empty;
                    components.SelectedGraphicsCardId = (result.GraphicsCard != null) ? result.GraphicsCard.Id.ToString() : string.Empty;
                    components.SelectedHardDriveId = (result.HardDrive != null) ? result.HardDrive.Id.ToString() : string.Empty;
                    components.SelectedMotherboardId = (result.Motherboard != null) ? result.Motherboard.Id.ToString() : string.Empty;
                    components.SelectedOtherId = (result.Other != null) ? result.Other.Id.ToString() : string.Empty;
                    components.SelectedPCCaseId = (result.PCCase != null) ? result.PCCase.Id.ToString() : string.Empty;
                    components.SelectedPowerSupplyId = (result.PowerSupply != null) ? result.PowerSupply.Id.ToString() : string.Empty;
                    components.SelectedProcessorId = (result.Processor != null) ? result.Processor.Id.ToString() : string.Empty;
                    components.SelectedRAMId = (result.RAM != null) ? result.RAM.Id.ToString() : string.Empty;
                }
            }


            return this.View(components);
        }

        // POST: Configurations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Components model)
        {
            try
            {
                var configuration = new
                {
                    id = id,
                    cpuWatercoolerId = model.SelectedCPUWatercoolerId,
                    description = model.Configuration.Description,
                    fanId = model.SelectedFanId,
                    graphicsCardId = model.SelectedGraphicsCardId,
                    hardDrivedId = model.SelectedHardDriveId,
                    motherboardId = model.SelectedMotherboardId,
                    otherId = model.SelectedOtherId,
                    pcCaseId = model.SelectedPCCaseId,
                    powerSupplyId = model.SelectedPowerSupplyId,
                    processorId = model.SelectedProcessorId,
                    ramId = model.SelectedRAMId,
                    totalPrice = model.Configuration.TotalPrice // to do
                };


                using (var httpClient = new HttpClient())
                {
                    
                    string json = JsonConvert.SerializeObject(configuration, Formatting.Indented);
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                    using (HttpResponseMessage response = await httpClient.PutAsync(string.Format("{0}/{1}", this.apiBaseUrl, this.apiController), httpContent))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();    // returns object, todo: change response in api to return successfull message
                        //ViewBag.Result = "Success";
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



        // GET: Configurations/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
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

        // POST: Configurations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Configuration configuration = null)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (HttpResponseMessage response = await httpClient.DeleteAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
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