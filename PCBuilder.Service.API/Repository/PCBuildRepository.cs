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

        //private readonly PCBuilderContext _dbContext;

        //public PCBuildRepository(PCBuilderContext dbContext)
        //{
        //    this._dbContext = dbContext;
        //}


        //public async Task<IEnumerable<PCBuild>> GetPCBuilds()
        //{
        //    return await this._dbContext.PCBuilds.Include(e => e.Processor).ToListAsync(); ;
        //}

        //public async Task<PCBuild> GetPCBuildsById(Guid id)
        //{
        //    return await this._dbContext.PCBuilds.FindAsync(id);
        //}

        //public async Task InsertPCBuild(PCBuild model)
        //{
        //    model.CreateDate = DateTime.UtcNow;
        //    model.ModifyDate = DateTime.UtcNow;

        //    await this._dbContext.AddAsync(model);
        //    await this.SaveAsync();
        //}

        //public async Task UpdatePCBuild(PCBuild model)
        //{
        //    model.ModifyDate = DateTime.UtcNow;

        //    this._dbContext.Entry(model).State = EntityState.Modified;
        //    await this.SaveAsync();
        //}

        //public async Task DeletePCBuild(Guid id)
        //{
        //    PCBuild build = this._dbContext.PCBuilds.Find(id);
        //    this._dbContext.PCBuilds.Remove(build);
        //    await this.SaveAsync();
        //}

        //public async Task SaveAsync()
        //{
        //    await this._dbContext.SaveChangesAsync();
        //}
    }
}
