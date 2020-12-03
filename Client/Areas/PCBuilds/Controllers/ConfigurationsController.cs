using Client.Areas.PCBuilds.Extensions;
using Client.Areas.PCBuilds.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
    [Area("PCBuilds")]
    [Authorize]
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
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}", this.apiBaseUrl, this.apiController));
            List<Configuration> configurationsList = JsonConvert.DeserializeObject<List<Configuration>>(response);

            return this.View(configurationsList);
        }

        // GET: Configurations/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id));
            Configuration configuration = JsonConvert.DeserializeObject<Configuration>(response);

            return this.View(configuration);
        }

        // GET: Configurations/Create
        public async Task<IActionResult> Create()
        {
            var components = new Components();
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            using (var httpClient = new HttpClient())
            {
                httpClient.SetBearerToken(accessToken);
                components = await this.ReturnListOfPcComponents(httpClient);
            }

            return this.View(components);
        }

        // POST: Configurations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Components model)
        {
            try
            {
                // todo: errors when at least one of the items is null
                var configuration = new
                {
                    cpuWatercoolerId = model.SelectedCPUWatercoolerId,
                    description = model.Configuration.Description,
                    fanId = model.SelectedFanId,
                    graphicsCardId = model.SelectedGraphicsCardId,
                    graphicsCardQty = model.Configuration.GraphicsCardQty,
                    pcBuildHardDrives = new List<HardDrive> { },
                    motherboardId = model.SelectedMotherboardId,
                    pcBuildOthers = new List<Other> { },
                    pcCaseId = model.SelectedPCCaseId,
                    powerSupplyId = model.SelectedPowerSupplyId,
                    processorId = model.SelectedProcessorId,
                    ramId = model.SelectedRAMId,
                };

                // iterate over selected hard drives and add them to the configuration object.
                if (model.SelectedHardDriveIds != null)
                {
                    foreach (string item in model.SelectedHardDriveIds)
                    {
                        configuration.pcBuildHardDrives.Add(
                             new HardDrive
                             {
                                 HardDriveId = Guid.Parse(item),
                             }
                        );
                    }
                }
                if (model.SelectedOtherIds != null)
                {
                    foreach (string item in model.SelectedOtherIds)
                    {
                        configuration.pcBuildOthers.Add(
                             new Other
                             {
                                 OtherId = Guid.Parse(item),
                             }
                        );
                    }
                }

                string accessToken = await this.HttpContext.GetTokenAsync("access_token");

                await ApiRequests.PostAsync(accessToken, string.Format("{0}/{1}", this.apiBaseUrl, this.apiController), configuration);

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return this.View();
            }
        }

        // GET: Configurations/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var components = new Components();
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            using (var httpClient = new HttpClient())
            {
                httpClient.SetBearerToken(accessToken);
                components = await this.ReturnListOfPcComponents(httpClient);

                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Configuration result = JsonConvert.DeserializeObject<Configuration>(apiResponse);

                    components.Configuration.Description = result?.Description;
                    components.Configuration.TotalPrice = result.TotalPrice;
                    components.Configuration.GraphicsCardQty = result.GraphicsCardQty;

                    components.SelectedCPUWatercoolerId = (result.CPUWatercooler != null) ? result.CPUWatercooler.CPUWatercoolerId.ToString() : string.Empty;
                    components.SelectedFanId = (result.Fan != null) ? result.Fan.FanId.ToString() : string.Empty;
                    components.SelectedGraphicsCardId = (result.GraphicsCard != null) ? result.GraphicsCard.GraphicsCardId.ToString() : string.Empty;

                    components.SelectedHardDriveIds = new List<string>();
                    result.pcBuildHardDrives.ForEach(x => components.SelectedHardDriveIds.Add(x.hardDriveId.ToString()));

                    components.SelectedMotherboardId = (result.Motherboard != null) ? result.Motherboard.MotherboardId.ToString() : string.Empty;

                    components.SelectedOtherIds = new List<string>();
                    result.pcBuildOthers.ForEach(x => components.SelectedOtherIds.Add(x.otherId.ToString()));

                    components.SelectedPCCaseId = (result.PCCase != null) ? result.PCCase.PCCaseId.ToString() : string.Empty;
                    components.SelectedPowerSupplyId = (result.PowerSupply != null) ? result.PowerSupply.PowerSupplyId.ToString() : string.Empty;
                    components.SelectedProcessorId = (result.Processor != null) ? result.Processor.ProcessorId.ToString() : string.Empty;
                    components.SelectedRAMId = (result.RAM != null) ? result.RAM.RamId.ToString() : string.Empty;
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
                    PCBuildId = id,
                    cpuWatercoolerId = model.SelectedCPUWatercoolerId,
                    description = model.Configuration.Description,
                    fanId = model.SelectedFanId,
                    graphicsCardId = model.SelectedGraphicsCardId,
                    graphicsCardQty = model.Configuration.GraphicsCardQty,
                    pcBuildHardDrives = new List<HardDrive> { },
                    motherboardId = model.SelectedMotherboardId,
                    pcBuildOthers = new List<Other> { },
                    pcCaseId = model.SelectedPCCaseId,
                    powerSupplyId = model.SelectedPowerSupplyId,
                    processorId = model.SelectedProcessorId,
                    ramId = model.SelectedRAMId
                };

                // iterate over selected hard drives and add them to the configuration object.
                if (model.SelectedHardDriveIds != null)
                {
                    foreach (string item in model.SelectedHardDriveIds)
                    {
                        configuration.pcBuildHardDrives.Add(
                             new HardDrive
                             {
                                 HardDriveId = Guid.Parse(item),
                             }
                        );
                    }
                }
                if (model.SelectedOtherIds != null)
                {
                    foreach (string item in model.SelectedOtherIds)
                    {
                        configuration.pcBuildOthers.Add(
                             new Other
                             {
                                 OtherId = Guid.Parse(item),
                             }
                        );
                    }
                }

                string accessToken = await this.HttpContext.GetTokenAsync("access_token");

                //using (var httpClient = new HttpClient())
                //{
                //    httpClient.SetBearerToken(accessToken);

                //    string json = JsonConvert.SerializeObject(configuration, Formatting.Indented);
                //    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                //    using (HttpResponseMessage response = await httpClient.PutAsync(string.Format("{0}/{1}", this.apiBaseUrl, this.apiController), httpContent))
                //    {
                //        string apiResponse = await response.Content.ReadAsStringAsync();    // returns object, todo: change response in api to return successfull message

                //    }
                //}

                await ApiRequests.PutAsync(accessToken, string.Format("{0}/{1}", this.apiBaseUrl, this.apiController), configuration);

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
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id));
            Configuration configuration = JsonConvert.DeserializeObject<Configuration>(response);

            return this.View(configuration);
        }

        // POST: Configurations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Configuration configuration = null)
        {
            try
            {
                string accessToken = await this.HttpContext.GetTokenAsync("access_token");

                await ApiRequests.DeleteAsync(accessToken, string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id));

                return this.RedirectToAction(nameof(Index));
            }
            catch
            {
                return this.View();
            }
        }

        /// <summary>
        /// Creates HttpResponseMessage object returning Component objects.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        private async Task<Components> ReturnListOfPcComponents(HttpClient httpClient)
        {
            // References: https://www.newtonsoft.com/json/help/html/ToObjectComplex.htm

            var components = new Components();

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
    }
}