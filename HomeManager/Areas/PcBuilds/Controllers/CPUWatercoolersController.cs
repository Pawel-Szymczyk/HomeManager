using HomeManager.Areas.PcBuilds.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomeManager.Areas.PcBuilds.Controllers
{
    [Area("PcBuilds")]
    public class CPUWatercoolersController : Controller
    {
        private readonly ILogger<CPUWatercoolersController> _logger;
        private readonly IConfiguration _configure;
        private readonly string apiBaseUrl;
        private readonly string apiController = "cpuwatercoolers";

        public CPUWatercoolersController(ILogger<CPUWatercoolersController> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configure = configuration;

            this.apiBaseUrl = this._configure.GetValue<string>("WebAPIBaseUrl");
        }


        // GET: CPUWatercooler
        public async Task<IActionResult> Index()
        {
            var cpuWatercoolerList = new List<CPUWatercooler>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}", this.apiBaseUrl, this.apiController)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cpuWatercoolerList = JsonConvert.DeserializeObject<List<CPUWatercooler>>(apiResponse);
                }
            }


            return this.View(cpuWatercoolerList);
        }

        // GET: CPUWatercooler/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var cpuWatercooler = new CPUWatercooler();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cpuWatercooler = JsonConvert.DeserializeObject<CPUWatercooler>(apiResponse);
                }
            }

            return this.View(cpuWatercooler);
        }



        // GET: CPUWatercooler/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: CPUWatercooler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CPUWatercooler model)
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

        // GET: CPUWatercooler/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var cpuWatercooler = new CPUWatercooler();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cpuWatercooler = JsonConvert.DeserializeObject<CPUWatercooler>(apiResponse);
                }
            }

            return this.View(cpuWatercooler);
        }

        // POST: CPUWatercooler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CPUWatercooler model)
        {
            try
            {
                if (model == null)
                {
                    return this.NotFound();
                }

                using (var httpClient = new HttpClient())
                {
                    model.CPUWatercoolerId = id;
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

        // GET: Processor/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cpuWatercooler = new CPUWatercooler();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cpuWatercooler = JsonConvert.DeserializeObject<CPUWatercooler>(apiResponse);
                }
            }

            return this.View(cpuWatercooler);
        }

        // POST: Processor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, CPUWatercooler cpuWatercooler = null)
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