using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;
using PCBuilder.Service.API.Repository;

namespace PCBuilder.Service.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PCBuildsController : ControllerBase
    {
        private readonly PCBuildRepository _repository;

        public PCBuildsController(PCBuildRepository repository)
        {
            this._repository = repository;
        }

        // GET: api/PCBuilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PCBuild>>> Get()
        {
            return await this._repository.GetAll() ;
        }

        // GET: api/PCBuilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PCBuild>> Get(Guid Id)
        {
            var build = await this._repository.Get(Id);

            if(build == null)
            {
                return NotFound();
            }

            return build;
        }

        // PUT: api/PCBuilds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PCBuild model)
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

        // POST: api/PCBuilds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PCBuild>> Post([FromBody] PCBuild model)
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

        // DELETE: api/PCBuilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PCBuild>> Delete(Guid Id)
        {

            try
            {
                var build = await this._repository.Delete(Id);
                if(build == null)
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
