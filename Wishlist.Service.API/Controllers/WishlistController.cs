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
        [HttpPost]
        public IActionResult Post([FromBody] WishlistEntity model)
        {
            try
            {
                model.Id = new Guid();

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
