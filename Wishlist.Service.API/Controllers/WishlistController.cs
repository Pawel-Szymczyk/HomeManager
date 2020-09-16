using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            _entityRepository = entityRepository;
        }

        // GET: api/Wishlist
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
            return _entityRepository.GetEntities();
        }

        // GET: api/Wishlist/5
        [HttpGet("{id}", Name = "Get")]
        public Entity Get(Guid id)
        {
            return _entityRepository.GetEntityById(id);
        }

        // POST: api/Wishlist
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
        ///         "occasion": 1,
        ///         "state": 1,
        ///         "category": 1
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
                //model.Id = new Guid();
                //model.CreateDate = DateTime.UtcNow;
                //model.ModifyDate = DateTime.UtcNow;

                //db.WishlistEntities.Add(model);
                //db.SaveChanges();

                using (var scope = new TransactionScope())
                {
                    _entityRepository.InsertEntity(model);
                    scope.Complete();
                    return StatusCode(StatusCodes.Status201Created, model);
                }

                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        //// PUT: api/Wishlist/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
