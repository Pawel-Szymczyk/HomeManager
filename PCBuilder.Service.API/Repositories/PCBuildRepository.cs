using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Repositories
{
    public class PCBuildRepository : Repository<PCBuild, PCBuilderContext>
    {
        private readonly PCBuilderContext _context;
        public PCBuildRepository(PCBuilderContext context) : base(context)
        {
            _context = context;
        }
        // We can add new methods specific to the movie repository here in the future

        public override async Task<PCBuild> Update(PCBuild model)
        {
            //this._context.PCBuilds.Attach(model);
            //this._context.Entry(model);
            //this._context.Entry(model).State = EntityState.Modified;

            //await this._context.SaveChangesAsync();

            return null;
        }

        public override async Task<List<PCBuild>> GetAll()
        {
            //return await this._context.PCBuilds
            //    .Include(e => e.CPUWatercooler)
            //    .Include(e => e.Fan)
            //    .Include(e => e.GraphicsCard)
            //    .Include(e => e.HardDrive)
            //    .Include(e => e.Motherboard)
            //    .Include(e => e.Others)
            //    .Include(e => e.PCCase)
            //    .Include(e => e.PowerSupply)
            //    .Include(e => e.Processor)
            //    .Include(e => e.RAM)
            //    .ToListAsync();


            //var objectList = await _context.PCBuilds.Select(p => new PCBuild
            //{
            //    PCBuildId = p.PCBuildId,
            //    PCBuildOthers = p.PCBuildOthers.Select(x => x.Other).ToList()
            //}).ToListAsync();

            var obj = await _context.PCBuilds.Include(x => x.PCBuildOthers).ThenInclude(x => x.Other).ToListAsync();

            return obj;

            //return await this._context.PCBuilds
            //    .Include(x => x.PCBuildOthers)
            //    .ToListAsync();

        }

        public override async Task<PCBuild> Get(Guid Id)
        {
            //return await this._context.PCBuilds
            //    .Include(e => e.CPUWatercooler)
            //    .Include(e => e.Fan)
            //    .Include(e => e.GraphicsCard)
            //    .Include(e => e.HardDrive)
            //    .Include(e => e.Motherboard)
            //    .Include(e => e.Others)
            //    .Include(e => e.PCCase)
            //    .Include(e => e.PowerSupply)
            //    .Include(e => e.Processor)
            //    .Include(e => e.RAM)
            //    .FirstOrDefaultAsync(e => e.Id == Id);

            return null;
        }


        
    }
}
