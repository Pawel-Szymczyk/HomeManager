using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.API.Models;
using PCBuilder.Service.API.Repositories;

namespace PCBuilder.Service.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class PowerSuppliesController : ControllerBase
    {
        private readonly PowerSupplyRepository _repository;

        public PowerSuppliesController(PowerSupplyRepository repository)
        {
            this._repository = repository;
        }


        /// <summary>
        /// Get list of all available power supplies.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/PowerSupplies
        /// </remarks>
        /// <returns>IEnumerable List of power supplies.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PowerSupply>>> Get()
        {
            return await this._repository.GetAll();
        }

        /// <summary>
        /// Get single power supply entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/PowerSupplies/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) Power supply identificator.</param>
        /// <returns>Return power supply object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PowerSupply>> Get(Guid Id)
        {
            PowerSupply powerSupply = await this._repository.Get(Id);

            if (powerSupply == null)
            {
                return this.NotFound();
            }

            return powerSupply;
        }

        /// <summary>
        /// Creates a power supply entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/PowerSupplies
        ///     {
        ///         "manufacturer": "be quiet!",
        ///         "model": "Pure Power 11 700W",
        ///         "power": "700W",
        ///         "color": "black",
        ///         "certificate": "80Plus Gold",
        ///         "modularCables": true,
        ///         "name": "PURE POWER 11 700W 80 PLUS GOLD MODULAR POWER SUPPLY",
        ///         "link": "no url",
        ///         "price": 94.99
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Power supply model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PowerSupply>> Post([FromBody] PowerSupply model)
        {
            try
            {
                model.CreatedDate = DateTime.UtcNow;
                model.ModifiedDate = DateTime.UtcNow;

                await this._repository.Add(model);
                return this.StatusCode(StatusCodes.Status201Created, model);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Updates a power supply entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/PowerSupplies
        ///     {
        ///         "id": "00000000-0000-0000-0000-000000000000",
        ///         "manufacturer": "be quiet!",
        ///         "model": "Pure Power 11 700W",
        ///         "power": "700W",
        ///         "color": "black",
        ///         "certificate": "80Plus Gold",
        ///         "modularCables": true,
        ///         "name": "PURE POWER 11 700W 80 PLUS GOLD MODULAR POWER SUPPLY",
        ///         "link": "no url",
        ///         "price": 94.99,
        ///         "createdDate": "0001-01-01T00:00:00",
        ///         "modifiedDate": "0001-01-01T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">A power supply model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="204">Returns no content message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] PowerSupply model)
        {
            try
            {
                if (model != null)
                {
                    model.ModifiedDate = DateTime.UtcNow;

                    await this._repository.Update(model);
                    return this.StatusCode(StatusCodes.Status201Created, model);
                }

                return this.StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Delete a single power supply entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/PowerSupplies/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) Power supply identificator.</param>
        /// <returns>Return successful message.</returns>
        /// <response code="404">Returns no found message.</response>
        /// <response code="200">Returns successful message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PowerSupply>> Delete(Guid Id)
        {

            try
            {
                PowerSupply powerSupply = await this._repository.Delete(Id);
                if (powerSupply == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound);
                }
                return this.StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}