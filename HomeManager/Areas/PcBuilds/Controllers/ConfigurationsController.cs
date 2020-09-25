using HomeManager.Areas.PcBuilds.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            // References: https://www.newtonsoft.com/json/help/html/ToObjectComplex.htm

            

            Components components = new Components();

            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}", this.apiBaseUrl, this.apiComponentsController)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    var jObject = JObject.Parse(apiResponse);


                    JArray cpuWatercoolers = (JArray)jObject["cpuWatercoolers"];
                    IList<CPUWatercooler> cpuWatercoolersList = cpuWatercoolers.ToObject<IList<CPUWatercooler>>();
                    components.CPUWatercoolers = new List<CPUWatercooler>(cpuWatercoolersList);

                    JArray fans = (JArray)jObject["fans"];
                    IList<Fan> fansList = fans.ToObject<IList<Fan>>();
                    components.Fans = new List<Fan>(fansList);

                    JArray graphicsCards = (JArray)jObject["graphicsCards"];
                    IList<GraphicsCard> graphicsCardsList = graphicsCards.ToObject<IList<GraphicsCard>>();
                    components.GraphicsCards = new List<GraphicsCard>(graphicsCardsList);

                    JArray hardDrives = (JArray)jObject["hardDrives"];
                    IList<HardDrive> hardDrivesList = hardDrives.ToObject<IList<HardDrive>>();
                    components.HardDrives = new List<HardDrive>(hardDrivesList);

                    JArray motherboards = (JArray)jObject["motherboards"];
                    IList<Motherboard> motherboardsList = motherboards.ToObject<IList<Motherboard>>();
                    components.Motherboards = new List<Motherboard>(motherboardsList);

                    JArray others = (JArray)jObject["others"];
                    IList<Other> othersList = others.ToObject<IList<Other>>();
                    components.Others = new List<Other>(othersList);

                    JArray pcCases = (JArray)jObject["pcCases"];
                    IList<PCCase> pcCasesList = pcCases.ToObject<IList<PCCase>>();
                    components.PCCases = new List<PCCase>(pcCasesList);

                    JArray powerSupplies = (JArray)jObject["powerSupplies"];
                    IList<PowerSupply> powerSuppliesList = powerSupplies.ToObject<IList<PowerSupply>>();
                    components.PowerSupplies = new List<PowerSupply>(powerSuppliesList);

                    JArray processors = (JArray)jObject["processors"];
                    IList<Processor> processorsList = processors.ToObject<IList<Processor>>();
                    components.Processors = new List<Processor>(processorsList);

                    JArray rams = (JArray)jObject["rams"];
                    IList<RAM> ramsList = rams.ToObject<IList<RAM>>();
                    components.RAMs = new List<RAM>(ramsList);


                }
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


        // GET: Fans/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            //var fan = new Fan();
            //using (var httpClient = new HttpClient())
            //{
            //    using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        fan = JsonConvert.DeserializeObject<Fan>(apiResponse);
            //    }
            //}

            return this.View();
        }



    }
}