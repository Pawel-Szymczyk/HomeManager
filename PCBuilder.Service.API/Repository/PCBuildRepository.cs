using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Repository
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
            return await this._context.PCBuilds.Include(e => e.Processor).ToListAsync();
        }

        public override async Task<PCBuild> Get(Guid Id)
        {
            return await this._context.PCBuilds.Include(e => e.Processor).FirstOrDefaultAsync(e => e.Id == Id);
        }

    }
}
