using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Repository
{
    public class PCBuildRepository : IPCBuildRepository
    {
        private readonly PCBuilderContext _dbContext;

        public PCBuildRepository(PCBuilderContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<PCBuild> GetPCBuilds()
        {
            var builds = _dbContext.PCBuilds
                .Include(e => e.Processor)
                .ToList();

            return builds;
        }

        public PCBuild GetPCBuildsById(Guid id)
        {
            return _dbContext.PCBuilds.Find(id);
        }

        public void InsertPCBuild(PCBuild model)
        {
            model.CreateDate = DateTime.UtcNow;
            model.ModifyDate = DateTime.UtcNow;

            _dbContext.Add(model);
            Save();
        }

        public void UpdatePCBuild(PCBuild model)
        {
            model.ModifyDate = DateTime.UtcNow;

            _dbContext.Entry(model).State = EntityState.Modified;
            Save();
        }

        public void DeletePCBuild(Guid id)
        {
            var build = _dbContext.PCBuilds.Find(id);
            _dbContext.PCBuilds.Remove(build);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
