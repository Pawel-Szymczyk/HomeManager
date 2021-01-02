using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class GraphicsCardsController : ControllerBase
    {
        private readonly GraphicsCardRepository _repository;

        public GraphicsCardsController(GraphicsCardRepository repository)
        {
            this._repository = repository;
        }


        /// <summary>
        /// Get list of all available graphics cards.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/GraphicsCards
        /// </remarks>
        /// <returns>IEnumerable List of graphics gards.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GraphicsCard>>> Get()
        {
            return await this._repository.GetAll();
        }

        /// <summary>
        /// Get single graphics card entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/GraphicsCards/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) Graphics card identificator.</param>
        /// <returns>Return graphics card object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GraphicsCard>> Get(Guid Id)
        {
            GraphicsCard graphicsCard = await this._repository.Get(Id);

            if (graphicsCard == null)
            {
                return this.NotFound();
            }

            return graphicsCard;
        }

        /// <summary>
        /// Creates a graphics card entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/GraphicsCards
        ///     {
        ///         "dimensions": "327 x 55.6 x 140 mm (W x H x D)",
        ///         "gpu": "GeForce RTX 2080 Ti",
        ///         "gpuFrequency": "1350 MHz",
        ///         "boostClock": "1755 MHz",
        ///         "memoryType": "GDDR6",
        ///         "cuda": 4452,
        ///         "psu": "650 Watt",
        ///         "name": "MSI GEFORCE RTX 2080 TI GAMING X TRIO",
        ///         "link": "no url",
        ///         "price": 128.99,
        ///     }
        ///
        /// </remarks>
        /// <param name="model">graphics card model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GraphicsCard>> Post([FromBody] GraphicsCard model)
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
        /// Updates a graphics card entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/GraphicsCards
        ///     {
        ///         "id": "00000000-0000-0000-0000-000000000000",
        ///         "dimensions": "327 x 55.6 x 140 mm (W x H x D)",
        ///         "gpu": "GeForce RTX 2080 Ti",
        ///         "gpuFrequency": "1350 MHz",
        ///         "boostClock": "1755 MHz",
        ///         "memoryType": "GDDR6",
        ///         "cuda": 4452,
        ///         "psu": "650 Watt",
        ///         "name": "MSI GEFORCE RTX 2080 TI GAMING X TRIO",
        ///         "link": "no url",
        ///         "price": 128.99,
        ///         "createdDate": "0001-01-01T00:00:00",
        ///         "modifiedDate": "0001-01-01T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Graphics card model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="204">Returns no content message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] GraphicsCard model)
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
        /// Delete single graphics card entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/GraphicsCards/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) Graphics card identificator.</param>
        /// <returns>Return successful message.</returns>
        /// <response code="404">Returns no found message.</response>
        /// <response code="200">Returns successful message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GraphicsCard>> Delete(Guid Id)
        {

            try
            {
                GraphicsCard graphicsCard = await this._repository.Delete(Id);
                if (graphicsCard == null)
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