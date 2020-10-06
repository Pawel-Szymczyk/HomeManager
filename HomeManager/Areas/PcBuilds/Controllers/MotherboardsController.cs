using HomeManager.Areas.PcBuilds.Models;
using HomeManager.Extentions;
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
    public class MotherboardsController : Controller
    {
        private readonly ILogger<MotherboardsController> _logger;
        private readonly IConfiguration _configure;
        private readonly string apiBaseUrl;
        private readonly string apiController = "motherboards";

        public MotherboardsController(ILogger<MotherboardsController> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configure = configuration;

            this.apiBaseUrl = this._configure.GetValue<string>("WebAPIBaseUrl");
        }


        // GET: Motherboards
        public async Task<IActionResult> Index()
        {
            var MotherboardList = new List<Motherboard>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}", this.apiBaseUrl, this.apiController)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    MotherboardList = JsonConvert.DeserializeObject<List<Motherboard>>(apiResponse);
                }
            }


            return this.View(MotherboardList);
        }

        // GET: Motherboards/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var motherboard = new Motherboard();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    motherboard = JsonConvert.DeserializeObject<Motherboard>(apiResponse);
                }
            }

            return this.View(motherboard);
        }



        // GET: Motherboards/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Motherboards/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Motherboard model)
        {
            try
            {
                if (model.ImageFile != null)
                {
                    model.ImageTitle = model.ImageFile.FileName;
                    model.ImageData = ImageManager.GetByteArrayFromImage(model.ImageFile);
                }

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

        // GET: Motherboards/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var motherboard = new Motherboard();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    motherboard = JsonConvert.DeserializeObject<Motherboard>(apiResponse);
                }
            }

            return this.View(motherboard);
        }

        // POST: Motherboards/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Motherboard model)
        {
            try
            {
                if (model == null)
                {
                    return this.NotFound();
                }

                if (model.ImageFile != null)
                {
                    model.ImageTitle = model.ImageFile.FileName;
                    model.ImageData = ImageManager.GetByteArrayFromImage(model.ImageFile);
                }

                using (var httpClient = new HttpClient())
                {
                    model.MotherboardId = id;
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

        // GET: Motherboards/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var motherboard = new Motherboard();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    motherboard = JsonConvert.DeserializeObject<Motherboard>(apiResponse);
                }
            }

            return this.View(motherboard);
        }

        // POST: Motherboards/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Motherboard motherboard = null)
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