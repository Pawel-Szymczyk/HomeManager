using HomeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeManager.Controllers.PCBuild
{

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

        //// GET: Processor/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Processor/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Processor/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Processor/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Processor/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Processor/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Processor/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}