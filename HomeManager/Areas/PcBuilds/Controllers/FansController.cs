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
    public class FansController : Controller
    {
        private readonly ILogger<FansController> _logger;
        private readonly IConfiguration _configure;
        private readonly string apiBaseUrl;
        private readonly string apiController = "fans";

        public FansController(ILogger<FansController> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configure = configuration;

            this.apiBaseUrl = this._configure.GetValue<string>("WebAPIBaseUrl");
        }


        // GET: Fans
        public async Task<IActionResult> Index()
        {
            var fanList = new List<Fan>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}", this.apiBaseUrl, this.apiController)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fanList = JsonConvert.DeserializeObject<List<Fan>>(apiResponse);
                }
            }


            return this.View(fanList);
        }

        // GET: Fans/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var fan = new Fan();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fan = JsonConvert.DeserializeObject<Fan>(apiResponse);
                }
            }

            return this.View(fan);
        }



        // GET: Fans/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Fans/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fan model)
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

        // GET: Fans/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var fan = new Fan();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fan = JsonConvert.DeserializeObject<Fan>(apiResponse);
                }
            }

            return this.View(fan);
        }

        // POST: Fans/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Fan model)
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
                    model.FanId = id;
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

        // GET: Fans/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fan = new Fan();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fan = JsonConvert.DeserializeObject<Fan>(apiResponse);
                }
            }

            return this.View(fan);
        }

        // POST: Fans/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Fan fan = null)
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