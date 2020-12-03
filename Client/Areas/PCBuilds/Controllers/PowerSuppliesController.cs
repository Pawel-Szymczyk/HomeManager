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
    [Authorize]
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
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}", this.apiBaseUrl, this.apiController));
            List<PowerSupply> powerSupplyList = JsonConvert.DeserializeObject<List<PowerSupply>>(response);

            return this.View(powerSupplyList);
        }

        // GET: PowerSupplies/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id));
            PowerSupply powerSupply = JsonConvert.DeserializeObject<PowerSupply>(response);

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
        public async Task<IActionResult> Create(PowerSupply powerSupplyModel)
        {
            try
            {
                if (powerSupplyModel.ImageFile != null)
                {
                    powerSupplyModel.ImageTitle = powerSupplyModel.ImageFile.FileName;
                    powerSupplyModel.ImageData = ImageManager.GetByteArrayFromImage(powerSupplyModel.ImageFile);
                }

                string accessToken = await this.HttpContext.GetTokenAsync("access_token");

                await ApiRequests.PostAsync(accessToken, string.Format("{0}/{1}", this.apiBaseUrl, this.apiController), powerSupplyModel);

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
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id));
            PowerSupply powerSupply = JsonConvert.DeserializeObject<PowerSupply>(response);

            return this.View(powerSupply);
        }

        // POST: PowerSupplies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PowerSupply powerSupplyModel)
        {
            try
            {
                if (powerSupplyModel == null)
                {
                    return this.NotFound();
                }

                if (powerSupplyModel.ImageFile != null)
                {
                    powerSupplyModel.ImageTitle = powerSupplyModel.ImageFile.FileName;
                    powerSupplyModel.ImageData = ImageManager.GetByteArrayFromImage(powerSupplyModel.ImageFile);
                }

                powerSupplyModel.PowerSupplyId = id;

                string accessToken = await this.HttpContext.GetTokenAsync("access_token");

                await ApiRequests.PutAsync(accessToken, string.Format("{0}/{1}", this.apiBaseUrl, this.apiController), powerSupplyModel);

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
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id));
            PowerSupply powerSupply = JsonConvert.DeserializeObject<PowerSupply>(response);

            return this.View(powerSupply);
        }

        // POST: PowerSupplies/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, PowerSupply powerSupply = null)
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