using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ComponentsController : ControllerBase
    {
        private readonly CPUWatercoolerRepository _cpuWatercoolerRepository;
        private readonly FanRepository _fanRepository;
        private readonly GraphicsCardRepository _graphicsCardRepository;
        private readonly HardDriveRepository _hardDriveRepository;
        private readonly MotherboardRepository _motherboardRepository;
        private readonly OtherRepository _otherRepository;
        private readonly PCCaseRepository _pcCaseRepository;
        private readonly PowerSupplyRepository _powerSupplyRepository;
        private readonly ProcessorRepository _processorRepository;
        private readonly RAMRepository _ramRepository;

        public ComponentsController(
            CPUWatercoolerRepository cpuWatercoolerRepository,
            FanRepository fanRepository,
            GraphicsCardRepository graphicsCardRepository,
            HardDriveRepository hardDriveRepository,
            MotherboardRepository motherboardRepository,
            OtherRepository otherRepository,
            PCCaseRepository pcCaseRepository,
            PowerSupplyRepository powerSupplyRepository,
            ProcessorRepository processorRepository,
            RAMRepository ramRepository)
        {
            this._cpuWatercoolerRepository = cpuWatercoolerRepository;
            this._fanRepository = fanRepository;
            this._graphicsCardRepository = graphicsCardRepository;
            this._hardDriveRepository = hardDriveRepository;
            this._motherboardRepository = motherboardRepository;
            this._otherRepository = otherRepository;
            this._pcCaseRepository = pcCaseRepository;
            this._powerSupplyRepository = powerSupplyRepository;
            this._processorRepository = processorRepository;
            this._ramRepository = ramRepository;
        }

        /// <summary>
        /// Get list of all pc components.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/Components
        /// </remarks>
        /// <returns>JSON object with list of components.</returns>
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            List<Models.CPUWatercooler> cpuWatercoolers = await this._cpuWatercoolerRepository.GetAll();
            List<Models.Fan> fans = await this._fanRepository.GetAll();
            List<Models.GraphicsCard> graphicsCards = await this._graphicsCardRepository.GetAll();
            List<Models.HardDrive> hardDrives = await this._hardDriveRepository.GetAll();
            List<Models.Motherboard> motherboards = await this._motherboardRepository.GetAll();
            List<Models.Other> others = await this._otherRepository.GetAll();
            List<Models.PCCase> pcCases = await this._pcCaseRepository.GetAll();
            List<Models.PowerSupply> powerSupplies = await this._powerSupplyRepository.GetAll();
            List<Models.Processor> processors = await this._processorRepository.GetAll();
            List<Models.RAM> rams = await this._ramRepository.GetAll();

            var models = new
            {
                cpuWatercoolers = cpuWatercoolers,
                fans = fans,
                graphicsCards = graphicsCards,
                hardDrives = hardDrives,
                motherboards = motherboards,
                others = others,
                pcCases = pcCases,
                powerSupplies = powerSupplies,
                processors = processors,
                rams = rams
            };

            var result = new JsonResult(models)
            {
                StatusCode = 200
            };

            return result;
        }

    }
}