﻿using Client;
using Client.Areas.PCBuilds.Extensions;
using Client.Areas.PCBuilds.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
    [Area("PCBuilds")]
    [Authorize]
    public class ProcessorsController : Controller
    {
        private readonly ILogger<ProcessorsController> _logger;
        private readonly IConfiguration _configure;
        private readonly string apiBaseUrl;
        private readonly string apiController = "processors";

        public ProcessorsController(ILogger<ProcessorsController> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configure = configuration;

            this.apiBaseUrl = this._configure.GetValue<string>("WebAPIBaseUrl");
        }


        // GET: Processor
        public async Task<IActionResult> Index()
        {
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}", this.apiBaseUrl, this.apiController));
            List<Processor> processorsList = JsonConvert.DeserializeObject<List<Processor>>(response);

            return this.View(processorsList);
        }

        // GET: Processor/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id));
            Processor processor = JsonConvert.DeserializeObject<Processor>(response);

            return this.View(processor);
        }

        // GET: Processor/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Processor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Processor model)
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

        // GET: Processor/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            string accessToken = await this.HttpContext.GetTokenAsync("access_token");

            string response = await ApiRequests.GetAsync(accessToken, string.Format("{0}/{1}/{2}", this.apiBaseUrl, this.apiController, id));
            Processor processor = JsonConvert.DeserializeObject<Processor>(response);

            return this.View(processor);
        }

        // POST: Processor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Processor model)
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

                model.ProcessorId = id; 

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
            Processor processor = JsonConvert.DeserializeObject<Processor>(response);

            return this.View(processor);
        }

        // POST: Processor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Processor processor = null)
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