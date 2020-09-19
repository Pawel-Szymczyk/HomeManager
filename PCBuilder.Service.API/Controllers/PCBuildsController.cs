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
    public class PCBuildsController : ControllerBase
    {
        private readonly PCBuildRepository _repository;

        public PCBuildsController(PCBuildRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Get list of all available pc builds.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/PCBuilds
        /// </remarks>
        /// <returns>IEnumerable List of PCBuilds.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PCBuild>>> Get()
        {
            return await this._repository.GetAll();
        }

        /// <summary>
        /// Get single pc build.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/PCBuilds/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) PCBuild identificator.</param>
        /// <returns>Return enity object.</returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<PCBuild>> Get(Guid Id)
        {
            PCBuild build = await this._repository.Get(Id);

            if (build == null)
            {
                return this.NotFound();
            }

            return build;
        }

        /// <summary>
        /// Creates a PC Build entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/PCBuilds
        ///     {
        ///         "description": "description",
        ///         "totalPrice": 0,
        ///         "processorId": "00000000-0000-0000-0000-000000000000",
        ///     }
        ///
        /// </remarks>
        /// <param name="model">PCBuild model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PCBuild>> Post([FromBody] PCBuild model)
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
        /// Updates a PC Build entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/PCBuilds
        ///     {
        ///         "id": "00000000-0000-0000-0000-000000000000",
        ///         "description": "description",
        ///         "totalPrice": 0,
        ///         "processorId": "00000000-0000-0000-0000-000000000000",
        ///         "createdDate": "2020-09-19T12:46:30.5102875+01:00",
        ///         "modifiedDate": "2020-09-19T12:46:30.5098872+01:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Entity model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="204">Returns no content message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] PCBuild model)
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
        /// Delete single pc build entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/PCBuilds/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) PC Build identificator.</param>
        /// <returns>Return successful message.</returns>
        /// <response code="404">Returns no found message.</response>
        /// <response code="200">Returns successful message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PCBuild>> Delete(Guid Id)
        {

            try
            {
                PCBuild build = await this._repository.Delete(Id);
                if (build == null)
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
