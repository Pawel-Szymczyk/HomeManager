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
    public class FansController : ControllerBase
    {
        private readonly FanRepository _repository;

        public FansController(FanRepository repository)
        {
            this._repository = repository;
        }


        /// <summary>
        /// Get list of all available fans.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/Fans
        /// </remarks>
        /// <returns>IEnumerable List of fans.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fan>>> Get()
        {
            return await this._repository.GetAll();
        }

        /// <summary>
        /// Get single fan entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/Fans/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) Fan identificator.</param>
        /// <returns>Return Fan object.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Fan>> Get(Guid Id)
        {
            Fan fan = await this._repository.Get(Id);

            if (fan == null)
            {
                return this.NotFound();
            }

            return fan;
        }

        /// <summary>
        /// Creates a fan entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/Fans
        ///     {
        ///         "dimensions": "120mm x 25mm",
        ///         "numberOfFuns": 3,
        ///         "pwmControl": true,
        ///         "rgb": true,
        ///         "name": "Corsair LL120 RGB, 120MM DUAL LIGHT LOOP RGB LED PWM FAN",
        ///         "link": "no url",
        ///         "price": 92.99
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Fan model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Fan>> Post([FromBody] Fan model)
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
        /// Updates a fan entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/Fans
        ///     {
        ///         "id": "00000000-0000-0000-0000-000000000000",
        ///         "dimensions": "120mm x 25mm",
        ///         "numberOfFuns": 3,
        ///         "pwmControl": true,
        ///         "rgb": true,
        ///         "name": "Corsair LL120 RGB, 120MM DUAL LIGHT LOOP RGB LED PWM FAN",
        ///         "link": "no url",
        ///         "price": 92.99,
        ///         "createdDate": "0001-01-01T00:00:00",
        ///         "modifiedDate": "0001-01-01T00:00:00"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">A fan model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="204">Returns no content message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] Fan model)
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
        /// Delete a single fan entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/Fans/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="Id">(Guid) Fan identificator.</param>
        /// <returns>Return successful message.</returns>
        /// <response code="404">Returns no found message.</response>
        /// <response code="200">Returns successful message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Fan>> Delete(Guid Id)
        {

            try
            {
                Fan fan = await this._repository.Delete(Id);
                if (fan == null)
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