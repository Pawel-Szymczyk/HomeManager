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
    public class PowerSuppliesController : Controller
    {
        private readonly ILogger<PowerSuppliesController> _logger;
        private readonly IConfiguration _configure;
        private readonly string apiBaseUrl;
        private readonly string apiController = "powersupplies";

        public PowerSuppliesController(ILogger<PowerSuppliesController> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configure = configuration;

            this.apiBaseUrl = this._configure.GetValue<string>("WebAPIBaseUrl");
        }


        // GET: PowerSupplies
        public async Task<IActionResult> Index()
        {
            var powerSupplyList = new List<PowerSupply>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}", this.apiBaseUrl, this.apiController)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    powerSupplyList = JsonConvert.DeserializeObject<List<PowerSupply>>(apiResponse);
                }
            }


            return this.View(powerSupplyList);
        }

        // GET: PowerSupplies/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var powerSupply = new PowerSupply();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    powerSupply = JsonConvert.DeserializeObject<PowerSupply>(apiResponse);
                }
            }

            return this.View(powerSupply);
        }



        // GET: PowerSupplies/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: PowerSupplies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PowerSupply model)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

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

        // GET: PowerSupplies/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var powerSupply = new PowerSupply();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    powerSupply = JsonConvert.DeserializeObject<PowerSupply>(apiResponse);
                }
            }

            return this.View(powerSupply);
        }

        // POST: PowerSupplies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PowerSupply model)
        {
            try
            {
                if (id != model.Id || model == null)
                {
                    return this.NotFound();
                }

                using (var httpClient = new HttpClient())
                {
                    model.Id = id;
                    string json = JsonConvert.SerializeObject(model, Formatting.Indented);
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

        // GET: PowerSupplies/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var powerSupply = new PowerSupply();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    powerSupply = JsonConvert.DeserializeObject<PowerSupply>(apiResponse);
                }
            }

            return this.View(powerSupply);
        }

        // POST: PowerSupplies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, PowerSupply powerSupply = null)
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