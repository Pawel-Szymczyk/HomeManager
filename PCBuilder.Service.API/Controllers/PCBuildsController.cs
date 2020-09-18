using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;

namespace PCBuilder.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCBuildsController : ControllerBase
    {
        private readonly PCBuilderContext _context;

        public PCBuildsController(PCBuilderContext context)
        {
            _context = context;
        }

        // GET: api/PCBuilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PCBuild>>> GetPCBuilds()
        {
            return await _context.PCBuilds.ToListAsync();
        }

        // GET: api/PCBuilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PCBuild>> GetPCBuild(Guid id)
        {
            var pCBuild = await _context.PCBuilds.FindAsync(id);

            if (pCBuild == null)
            {
                return NotFound();
            }

            return pCBuild;
        }

        // PUT: api/PCBuilds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPCBuild(Guid id, PCBuild pCBuild)
        {
            if (id != pCBuild.Id)
            {
                return BadRequest();
            }

            _context.Entry(pCBuild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PCBuildExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PCBuilds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PCBuild>> PostPCBuild(PCBuild pCBuild)
        {
            _context.PCBuilds.Add(pCBuild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPCBuild", new { id = pCBuild.Id }, pCBuild);
        }

        // DELETE: api/PCBuilds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PCBuild>> DeletePCBuild(Guid id)
        {
            var pCBuild = await _context.PCBuilds.FindAsync(id);
            if (pCBuild == null)
            {
                return NotFound();
            }

            _context.PCBuilds.Remove(pCBuild);
            await _context.SaveChangesAsync();

            return pCBuild;
        }

        private bool PCBuildExists(Guid id)
        {
            return _context.PCBuilds.Any(e => e.Id == id);
        }
    }
}
