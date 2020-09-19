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
    public class RAMsController : ControllerBase
    {
        private readonly RAMRepository _repository;

        public RAMsController(RAMRepository repository)
        {
            this._repository = repository;
        }


        /// <summary>
        /// Get list of all available RAM modules.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/RAMs
        /// </remarks>
        /// <returns>IEnumerable List of RAM modules.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RAM>>> Get()
        {
            return await this._repository.GetAll();
        }

        /// <summary>
        /// Get single RAM entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/RAMs/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) RAM identificator.</param>
        /// <returns>Return RAM object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RAM>> Get(Guid Id)
        {
            RAM ram = await this._repository.Get(Id);

            if (ram == null)
            {
                return this.NotFound();
            }

            return ram;
        }

        /// <summary>
        /// Creates a RAM entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/RAMs
        ///     {
        ///         "memoryType": "DDR4",
        ///         "memorySpeed": "DDR4-3600 MHz (PC4-28800)",
        ///         "capacity": "16GB",
        ///         "chipsetCompatibility": "Intel Z170, Intel Z270, Z390, Z490, X399 and AMD X370, X470, X570, B350, B450",
        ///         "numberOfModules": "2",
        ///         "name": "TEAM GROUP RIPPED EDITION ",
        ///         "link": "no url",
        ///         "price": 128.99,
        ///     }
        ///
        /// </remarks>
        /// <param name="model">RAM model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RAM>> Post([FromBody] RAM model)
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
        /// Updates a RAM entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/RAMs
        ///     {
        ///         "id": "00000000-0000-0000-0000-000000000000",
        ///         "memoryType": "DDR4",
        ///         "memorySpeed": "DDR4-3600 MHz (PC4-28800)",
        ///         "capacity": "16GB",
        ///         "chipsetCompatibility": "Intel Z170, Intel Z270, Z390, Z490, X399 and AMD X370, X470, X570, B350, B450",
        ///         "numberOfModules": "2",
        ///         "name": "TEAM GROUP RIPPED EDITION ",
        ///         "link": "no url",
        ///         "price": 128.99,
        ///         "createdDate": "0001-01-01T00:00:00",
        ///         "modifiedDate": "0001-01-01T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">RAM model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="204">Returns no content message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] RAM model)
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
        /// Delete single RAM entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/RAMs/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) RAM identificator.</param>
        /// <returns>Return successful message.</returns>
        /// <response code="404">Returns no found message.</response>
        /// <response code="200">Returns successful message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RAM>> Delete(Guid Id)
        {

            try
            {
                RAM ram = await this._repository.Delete(Id);
                if (ram == null)
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