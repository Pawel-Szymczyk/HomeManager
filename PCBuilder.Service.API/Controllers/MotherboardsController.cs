using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.API.Models;
using PCBuilder.Service.API.Repository;

namespace PCBuilder.Service.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MotherboardsController : ControllerBase
    {
        private readonly MotherboardRepository _repository;

        public MotherboardsController(MotherboardRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Get list of all available motherboards.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/Motherboards
        /// </remarks>
        /// <returns>IEnumerable List of motherboards.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motherboard>>> Get()
        {
            return await this._repository.GetAll();
        }

        /// <summary>
        /// Get single motherboard.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/Motherboards/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) Motherboard identificator.</param>
        /// <returns>Return motherboard object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Motherboard>> Get(Guid Id)
        {
            Motherboard motherboard = await this._repository.Get(Id);

            if (motherboard == null)
            {
                return this.NotFound();
            }

            return motherboard;
        }

        /// <summary>
        /// Creates a motherboard entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/Motherboards
        ///     {
        ///         "formFactor": "ATX",
        ///         "memory": "4x DDR4 (max. 2.933 MHz, 3.466 via OC)",
        ///         "socket": "AM4",
        ///         "chipset": "AMD B450",
        ///         "cpu": "2nd gen Ryzen processors",
        ///         "name": "MSI B450 Tomahawk",
        ///         "link": "no url",
        ///         "price": 109.99,
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Motherboard model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Motherboard>> Post([FromBody] Motherboard model)
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
        /// Updates a motherboard entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/Motherboards
        ///     {
        ///         "id": "00000000-0000-0000-0000-000000000000",
        ///         "formFactor": "ATX",
        ///         "memory": "4x DDR4 (max. 2.933 MHz, 3.466 via OC)",
        ///         "socket": "AM4",
        ///         "chipset": "AMD B450",
        ///         "cpu": "2nd gen Ryzen processors",
        ///         "name": "MSI B450 Tomahawk",
        ///         "link": "no url",
        ///         "price": 109.99,
        ///         "createdDate": "0001-01-01T00:00:00",
        ///         "modifiedDate": "0001-01-01T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Motherboard model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="204">Returns no content message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] Motherboard model)
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
        /// Delete single motherboard entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/Motherboards/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) Motherboard identificator.</param>
        /// <returns>Return successful message.</returns>
        /// <response code="404">Returns no found message.</response>
        /// <response code="200">Returns successful message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Motherboard>> Delete(Guid Id)
        {

            try
            {
                Motherboard motherboard = await this._repository.Delete(Id);
                if (motherboard == null)
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