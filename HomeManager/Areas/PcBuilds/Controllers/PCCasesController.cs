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
    public class PCCasesController : Controller
    {
        private readonly ILogger<PCCasesController> _logger;
        private readonly IConfiguration _configure;
        private readonly string apiBaseUrl;
        private readonly string apiController = "pccases";

        public PCCasesController(ILogger<PCCasesController> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configure = configuration;

            this.apiBaseUrl = this._configure.GetValue<string>("WebAPIBaseUrl");
        }


        // GET: PCCases
        public async Task<IActionResult> Index()
        {
            var pcCaseList = new List<PCCase>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}", this.apiBaseUrl, this.apiController)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pcCaseList = JsonConvert.DeserializeObject<List<PCCase>>(apiResponse);
                }
            }


            return this.View(pcCaseList);
        }

        // GET: PCCases/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var pcCase = new PCCase();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pcCase = JsonConvert.DeserializeObject<PCCase>(apiResponse);
                }
            }

            return this.View(pcCase);
        }



        // GET: PCCases/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: PCCases/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PCCase model)
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

        // GET: PCCases/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var pcCase = new PCCase();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pcCase = JsonConvert.DeserializeObject<PCCase>(apiResponse);
                }
            }

            return this.View(pcCase);
        }

        // POST: PCCases/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PCCase model)
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
                    model.PCCaseId = id;
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

        // GET: PCCases/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var pcCase = new PCCase();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id)))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pcCase = JsonConvert.DeserializeObject<PCCase>(apiResponse);
                }
            }

            return this.View(pcCase);
        }

        // POST: PCCases/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, PCCase pcCase = null)
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