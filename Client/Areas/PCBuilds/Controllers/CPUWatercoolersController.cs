using Client;
using Client.Areas.PCBuilds.Extensions;
using Client.Areas.PCBuilds.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeManager.Areas.PcBuilds.Controllers
{
    [Area("PCBuilds")]
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
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}", this.apiBaseUrl, this.apiController));
            List<CPUWatercooler> cpuWatercoolerList = JsonConvert.DeserializeObject<List<CPUWatercooler>>(response);

            return this.View(cpuWatercoolerList);
        }

        // GET: CPUWatercooler/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id));
            CPUWatercooler cpuWatercooler = JsonConvert.DeserializeObject<CPUWatercooler>(response);

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
                if (model.ImageFile != null)
                {
                    model.ImageTitle = model.ImageFile.FileName;
                    model.ImageData = ImageManager.GetByteArrayFromImage(model.ImageFile);
                }

                string accessToken = await this.HttpContext.GetTokenAsync("access_token");

                await ApiRequests.PostAsync(accessToken, string.Format("{0}/{1}", this.apiBaseUrl, this.apiController), model);

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
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id));
            CPUWatercooler cpuWatercooler = JsonConvert.DeserializeObject<CPUWatercooler>(response);

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

                if (model.ImageFile != null)
                {
                    model.ImageTitle = model.ImageFile.FileName;
                    model.ImageData = ImageManager.GetByteArrayFromImage(model.ImageFile);
                }

                model.CPUWatercoolerId = id;

                string accessToken = await this.HttpContext.GetTokenAsync("access_token");

                await ApiRequests.PutAsync(accessToken, string.Format("{0}/{1}", this.apiBaseUrl, this.apiController), model);

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
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id));
            CPUWatercooler cpuWatercooler = JsonConvert.DeserializeObject<CPUWatercooler>(response);

            return this.View(cpuWatercooler);
        }

        // POST: Processor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, CPUWatercooler cpuWatercooler = null)
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
    }
}