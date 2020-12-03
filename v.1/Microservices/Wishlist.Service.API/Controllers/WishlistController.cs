using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Transactions;
using Wishlist.Service.API.Models;
using Wishlist.Service.API.Repository;

namespace Wishlist.Service.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IEntityRepository _entityRepository;

        public WishlistController(IEntityRepository entityRepository)
        {
            this._entityRepository = entityRepository;
        }

        /// <summary>
        /// Get list of wish entities.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/Wishlist
        /// </remarks>
        /// <returns>List of WishlistEntities</returns>
        [HttpGet]
        public IEnumerable<Entity> Get()
        {
            return this._entityRepository.GetEntities();
        }

        /// <summary>
        /// Get single entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/Wishlist/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="id">(Guid) Entity identificator.</param>
        /// <returns>Return enity object.</returns>
        [HttpGet("{id}", Name = "Get")]
        public Entity Get(Guid id)
        {
            return this._entityRepository.GetEntityById(id);
        }

        /// <summary>
        /// Creates a Wishlist entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/v1/Wishlist
        ///     {
        ///         "name": "pc",
        ///         "description": "black case",
        ///         "websiteUrl": "https://www.google.com",
        ///         "price": 1500.50,
        ///         "occasionId": 00000000-0000-0000-0000-000000000000,
        ///         "stateId": 00000000-0000-0000-0000-000000000000,
        ///         "categoryId": 00000000-0000-0000-0000-000000000000
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Entity model (object).</param>
        /// <response code="201">Returns the newly created entity.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] Entity model)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    this._entityRepository.InsertEntity(model);
                    scope.Complete();
                    return this.StatusCode(StatusCodes.Status201Created, model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        /// <summary>
        /// Updates a Wishlist entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/v1/Wishlist
        ///     {
        ///         "id": "c21f6369-554c-42d3-7ad1-08d85b2f6c0f",
        ///         "name": "pc",
        ///         "description": "black case",
        ///         "websiteUrl": "https://www.google.com",
        ///         "price": 1500.50,
        ///         "occasionId": 00000000-0000-0000-0000-000000000000,
        ///         "stateId": 00000000-0000-0000-0000-000000000000,
        ///         "categoryId": 00000000-0000-0000-0000-000000000000
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
        public IActionResult Put([FromBody] Entity model)
        {
            try
            {
                if (model != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        this._entityRepository.UpdateEntity(model);
                        scope.Complete();
                        return this.StatusCode(StatusCodes.Status201Created, model);
                    }
                }

                return this.StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Delete single entity.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /api/v1/Wishlist/00000000-0000-0000-0000-000000000000
        /// </remarks>
        /// <param name="id">(Guid) Entity identificator.</param>
        /// <returns>Return successful message.</returns>
        /// <response code="200">Returns successful message.</response>
        /// <response code="500">If there was any problem with creating entity.</response>   
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                this._entityRepository.DeleteEntity(id);
                return this.StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
