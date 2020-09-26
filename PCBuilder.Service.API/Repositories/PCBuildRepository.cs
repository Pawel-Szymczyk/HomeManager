using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;
using System;
using System.Collections.Generic;
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

        public override async Task<List<PCBuild>> GetAll()
        {
            return await this._context.PCBuilds
                .Include(e => e.CPUWatercooler)
                .Include(e => e.Fan)
                .Include(e => e.GraphicsCard)
                .Include(e => e.HardDrive)
                .Include(e => e.Motherboard)
                .Include(e => e.Other)
                .Include(e => e.PCCase)
                .Include(e => e.PowerSupply)
                .Include(e => e.Processor)
                .Include(e => e.RAM)
                .ToListAsync();
        }

        public override async Task<PCBuild> Get(Guid Id)
        {
            return await this._context.PCBuilds
                .Include(e => e.CPUWatercooler)
                .Include(e => e.Fan)
                .Include(e => e.GraphicsCard)
                .Include(e => e.HardDrive)
                .Include(e => e.Motherboard)
                .Include(e => e.Other)
                .Include(e => e.PCCase)
                .Include(e => e.PowerSupply)
                .Include(e => e.Processor)
                .Include(e => e.RAM)
                .FirstOrDefaultAsync(e => e.Id == Id);
        }

    }
}
