using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.API.Models;
using PCBuilder.Service.API.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HardDrivesController : ControllerBase
    {
        private readonly HardDriveRepository _repository;

        public HardDrivesController(HardDriveRepository repository)
        {
            this._repository = repository;
        }


        /// <summary>
        /// Get list of all available hard drives.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/HardDrives
        /// </remarks>
        /// <returns>IEnumerable List of hard drives.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HardDrive>>> Get()
        {
            return await this._repository.GetAll();
        }

        /// <summary>
        /// Get single hard drive entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/HardDrives/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) Hard drive identificator.</param>
        /// <returns>Return hard drive object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<HardDrive>> Get(Guid Id)
        {
            HardDrive hardDrive = await this._repository.Get(Id);

            if (hardDrive == null)
            {
                return this.NotFound();
            }

            return hardDrive;
        }

        /// <summary>
        /// Creates a hard drive entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/HardDrives
        ///     {
        ///         "capacity": "1TB",
        ///         "type": "SSD ",
        ///         "name": "WD Blue PC SSD",
        ///         "link": "no url",
        ///         "price": 99.99
        ///     }
        ///
        /// </remarks>
        /// <param name="model">hard drive model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HardDrive>> Post([FromBody] HardDrive model)
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
        /// Updates a hard drive entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/HardDrives
        ///     {
        ///         "id": "00000000-0000-0000-0000-000000000000",
        ///         "capacity": "1TB",
        ///         "type": "SSD ",
        ///         "name": "WD Blue PC SSD",
        ///         "link": "no url",
        ///         "price": 99.99
        ///         "createdDate": "0001-01-01T00:00:00",
        ///         "modifiedDate": "0001-01-01T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Hard drive model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="204">Returns no content message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] HardDrive model)
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
        /// Delete single hard drive entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/HardDrives/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) Hard drive identificator.</param>
        /// <returns>Return successful message.</returns>
        /// <response code="404">Returns no found message.</response>
        /// <response code="200">Returns successful message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HardDrive>> Delete(Guid Id)
        {

            try
            {
                HardDrive hardDrive = await this._repository.Delete(Id);
                if (hardDrive == null)
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