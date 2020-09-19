using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;
using PCBuilder.Service.API.Repository;

namespace PCBuilder.Service.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProcessorsController : ControllerBase
    {
        private readonly ProcessorRepository _repository;

        public ProcessorsController(ProcessorRepository repository)
        {
            _repository = repository;
        }

        
        /// <summary>
        /// Get list of all available processors.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/Processors
        /// </remarks>
        /// <returns>IEnumerable List of processors.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Processor>>> Get()
        {
            return await this._repository.GetAll();
        }

        /// <summary>
        /// Get single processor.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/Processors/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) Processor identificator.</param>
        /// <returns>Return processor object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Processor>> Get(Guid Id)
        {
            Processor processor = await this._repository.Get(Id);

            if (processor == null)
            {
                return this.NotFound();
            }

            return processor;
        }

        /// <summary>
        /// Creates a processor entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/Processors
        ///     {
        ///         "productCollection": "i7 10th gen",
        ///         "numberOfCores": 4,
        ///         "numberOfThreads": 4,
        ///         "cache": 8,
        ///         "tdp": 100,
        ///         "processorBaseFrequency": 1,
        ///         "name": "i7",
        ///         "link": "no url",
        ///         "price": 0,
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Processor model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Processor>> Post([FromBody] Processor model)
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
        /// Updates a processor entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/Processors
        ///     {
        ///         "id": "00000000-0000-0000-0000-000000000000",
        ///         "productCollection": "i7 10th gen",
        ///         "numberOfCores": 4,
        ///         "numberOfThreads": 4,
        ///         "cache": 8,
        ///         "tdp": 100,
        ///         "processorBaseFrequency": 1,
        ///         "name": "i7",
        ///         "link": "no url",
        ///         "price": 0,
        ///         "createdDate": "0001-01-01T00:00:00",
        ///         "modifiedDate": "0001-01-01T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Processor model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="204">Returns no content message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] Processor model)
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
        /// Delete single processor entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/Processors/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) Processor identificator.</param>
        /// <returns>Return successful message.</returns>
        /// <response code="404">Returns no found message.</response>
        /// <response code="200">Returns successful message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Processor>> Delete(Guid Id)
        {

            try
            {
                Processor processor = await this._repository.Delete(Id);
                if (processor == null)
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
