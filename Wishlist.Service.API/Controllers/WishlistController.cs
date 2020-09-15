using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wishlist.Service.API.Database;
using Wishlist.Service.API.Database.Entities;

namespace Wishlist.Service.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        DatabaseContext db;

        public WishlistController()
        {
            db = new DatabaseContext();
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
        public IEnumerable<WishlistEntity> Get()
        {
            return db.WishlistEntities.ToList();
        }

        // GET: api/Wishlist/5
        [HttpGet("{id}", Name = "Get")]
        public WishlistEntity Get(int id)
        {
            return this.db.WishlistEntities.Find(id);
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
        public IActionResult Post([FromBody] WishlistEntity model)
        {
            try
            {
                model.Id = new Guid();
                model.CreateDate = DateTime.UtcNow;
                model.ModifyDate = DateTime.UtcNow;

                db.WishlistEntities.Add(model);
                db.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, model);
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
