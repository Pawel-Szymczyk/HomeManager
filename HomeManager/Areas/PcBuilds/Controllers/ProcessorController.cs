
using HomeManager.Areas.PcBuilds.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomeManager.Areas.PcBuilds.Controllers
{
    [Area("PcBuilds")]
    public class ProcessorController : Controller
    {
        private readonly ILogger<ProcessorController> _logger;
        private readonly IConfiguration _configure;
        private readonly string apiBaseUrl;

        public ProcessorController(ILogger<ProcessorController> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configure = configuration;

            this.apiBaseUrl = this._configure.GetValue<string>("WebAPIBaseUrl");
        }


        // GET: Processor
        public async Task<IActionResult> Index()
        {
            var processorsList = new List<Processor>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/processors", this.apiBaseUrl)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    processorsList = JsonConvert.DeserializeObject<List<Processor>>(apiResponse);
                }
            }


            return this.View(processorsList);
        }

        // GET: Processor/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            Processor processor = new Processor();
            using(var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/processors/{1}", this.apiBaseUrl, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    processor = JsonConvert.DeserializeObject<Processor>(apiResponse);
                }
            }

            return this.View(processor);
        }



        // GET: Processor/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Processor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Processor model)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(string.Format("{0}/processors", this.apiBaseUrl), content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        //receivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Processor/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            Processor processor = new Processor();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/processors/{1}", this.apiBaseUrl, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    processor = JsonConvert.DeserializeObject<Processor>(apiResponse);
                }
            }

            return this.View(processor);
        }

        // POST: Processor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Processor model)
        {
            try
            {
                if (id != model.Id || model == null)
                {
                    return NotFound();
                }

                using (var httpClient = new HttpClient())
                {
                    model.Id = id;
                    string json = JsonConvert.SerializeObject(model, Formatting.Indented);
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync(string.Format("{0}/processors", this.apiBaseUrl), httpContent))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();    // returns object, todo: change response in api to return successfull message
                        //ViewBag.Result = "Success";
                        //receivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Processor/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            Processor processor = new Processor();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/processors/{1}", this.apiBaseUrl, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    processor = JsonConvert.DeserializeObject<Processor>(apiResponse);
                }
            }

            return View(processor);
        }

        // POST: Processor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Processor processor = null)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(string.Format("{0}/processors/{1}", this.apiBaseUrl, id)))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}