using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.API.Models;
using PCBuilder.Service.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CPUWatercoolersController : ControllerBase
    {
        private readonly CPUWatercoolerRepository _repository;

        public CPUWatercoolersController(CPUWatercoolerRepository repository)
        {
            this._repository = repository;
        }


        /// <summary>
        /// Get list of all available cpu watercoolers.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/CPUWatercoolers
        /// </remarks>
        /// <returns>IEnumerable List of cpu watercoolers.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CPUWatercooler>>> Get()
        {
            return await this._repository.GetAll();
        }

        /// <summary>
        /// Get single cpu watercooler entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/CPUWatercoolers/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) CPU watercooler identificator.</param>
        /// <returns>Return CPU watercooler object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CPUWatercooler>> Get(Guid Id)
        {
            CPUWatercooler cpuWatercooler = await this._repository.Get(Id);

            if (cpuWatercooler == null)
            {
                return this.NotFound();
            }

            return cpuWatercooler;
        }

        /// <summary>
        /// Creates a cpu watercooler entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/CPUWatercoolers
        ///     {
        ///         "dimensions": "277mm x 120mm x 27mm",
        ///         "socketsCompatibility": "Intel 1200, Intel 115x, Intel 1366, Intel 2011/2066, AMD AM3/AM2, AMD AM4, AMD FM1/FM2, AMD sTR4",
        ///         "numberOfFans": 2",
        ///         "name": "Corsair HYDRO SERIES H100I PLATINUM SE ADDRESSABLE RGB PERFORMANCE LIQUID",
        ///         "link": "no url",
        ///         "price": 109.99
        ///     }
        ///
        /// </remarks>
        /// <param name="model">CPU watercooler model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CPUWatercooler>> Post([FromBody] CPUWatercooler model)
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
        /// Updates a cpu watercooler entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/CPUWatercoolers
        ///     {
        ///         "id": "00000000-0000-0000-0000-000000000000",
        ///         "dimensions": "277mm x 120mm x 27mm",
        ///         "socketsCompatibility": "Intel 1200, Intel 115x, Intel 1366, Intel 2011/2066, AMD AM3/AM2, AMD AM4, AMD FM1/FM2, AMD sTR4",
        ///         "numberOfFans": 2",
        ///         "name": "Corsair HYDRO SERIES H100I PLATINUM SE ADDRESSABLE RGB PERFORMANCE LIQUID",
        ///         "link": "no url",
        ///         "price": 109.99,
        ///         "createdDate": "0001-01-01T00:00:00",
        ///         "modifiedDate": "0001-01-01T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">CPU watercooler model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="204">Returns no content message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] CPUWatercooler model)
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
        /// Delete a single cpu watercooler entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/CPUWatercoolers/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) CPU watercooler identificator.</param>
        /// <returns>Return successful message.</returns>
        /// <response code="404">Returns no found message.</response>
        /// <response code="200">Returns successful message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CPUWatercooler>> Delete(Guid Id)
        {

            try
            {
                CPUWatercooler cpuWatercooler = await this._repository.Delete(Id);
                if (cpuWatercooler == null)
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