using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.API.Models;
using PCBuilder.Service.API.Repositories;

namespace PCBuilder.Service.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PCCasesController : ControllerBase
    {
        private readonly PCCaseRepository _repository;

        public PCCasesController(PCCaseRepository repository)
        {
            this._repository = repository;
        }


        /// <summary>
        /// Get list of all available pc cases.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/PCCases
        /// </remarks>
        /// <returns>IEnumerable List of pc cases.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PCCase>>> Get()
        {
            return await this._repository.GetAll();
        }

        /// <summary>
        /// Get single pc case entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/PCCases/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) PC case identificator.</param>
        /// <returns>Return pc case object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PCCase>> Get(Guid Id)
        {
            PCCase pcCase = await this._repository.Get(Id);

            if (pcCase == null)
            {
                return this.NotFound();
            }

            return pcCase;
        }

        /// <summary>
        /// Creates a pc case entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/PCCases
        ///     {
        ///         "manufacturer": "Phanteks",
        ///         "formFactor": "Full tower",
        ///         "color": "black",
        ///         "motherboardSupport": "SSI-EEB, E-ATX, ATX, micro-ATX, mini-ITX",
        ///         "sideWindow": "Tempered Glass Window",
        ///         "name": "ENTHOO PRO 2 FULL TOWER CASE TEMPERED GLASS WINDOW DRGB SATIN BLACK",
        ///         "link": "no url",
        ///         "price": 124.99
        ///     }
        ///
        /// </remarks>
        /// <param name="model">PC case model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PCCase>> Post([FromBody] PCCase model)
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
        /// Updates a pc case entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/PCCases
        ///     {
        ///         "id": "00000000-0000-0000-0000-000000000000",
        ///         "manufacturer": "Phanteks",
        ///         "formFactor": "Full tower",
        ///         "color": "black",
        ///         "motherboardSupport": "SSI-EEB, E-ATX, ATX, micro-ATX, mini-ITX",
        ///         "sideWindow": "Tempered Glass Window",
        ///         "name": "ENTHOO PRO 2 FULL TOWER CASE TEMPERED GLASS WINDOW DRGB SATIN BLACK",
        ///         "link": "no url",
        ///         "price": 124.99
        ///         "createdDate": "0001-01-01T00:00:00",
        ///         "modifiedDate": "0001-01-01T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">A pc case model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="204">Returns no content message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] PCCase model)
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
        /// Delete a single pc case entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/PCCases/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) PC case identificator.</param>
        /// <returns>Return successful message.</returns>
        /// <response code="404">Returns no found message.</response>
        /// <response code="200">Returns successful message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PCCase>> Delete(Guid Id)
        {

            try
            {
                PCCase pcCase = await this._repository.Delete(Id);
                if (pcCase == null)
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