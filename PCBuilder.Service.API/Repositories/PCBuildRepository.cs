using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.API.DBContext;
using PCBuilder.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.Repositories
{
    public class PCBuildRepository : Repository<PCBuild, PCBuilderContext>
    {
        private readonly PCBuilderContext _context;
        public PCBuildRepository(PCBuilderContext context) : base(context)
        {
            this._context = context;
        }
        // We can add new methods specific to the movie repository here in the future


        public override async Task<PCBuild> Update(PCBuild model)
        {
            // the problem here is why normal update is not working?
            try
            {
                // get list of all items with model id from db
                List<PCBuild> buildsList = await this._context.PCBuilds.Where(b => b.PCBuildId == model.PCBuildId).ToListAsync();
                // remove these objs from db
                if (buildsList.Count > 0)
                {
                    this._context.RemoveRange(buildsList);
                    await this._context.SaveChangesAsync();
                }

                // add pcbuild id to each of referencing objects in the model
                model.PCBuildHardDrives?.ForEach(x => x.PCBuildId = model.PCBuildId);
                model.PCBuildOthers?.ForEach(x => x.PCBuildId = model.PCBuildId);


                // add model to db and save changes
                await this._context.AddAsync(model);
                await this._context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }





            return null;
        }

        public override async Task<List<PCBuild>> GetAll()
        {

            List<PCBuild> models = await this._context.PCBuilds
                .Include(e => e.CPUWatercooler)
                .Include(e => e.Fan)
                .Include(e => e.GraphicsCard)
                .Include(e => e.Motherboard)
                .Include(e => e.PCCase)
                .Include(e => e.PowerSupply)
                .Include(e => e.Processor)
                .Include(e => e.RAM)
                .Include(x => x.PCBuildHardDrives).ThenInclude(x => x.HardDrive)
                .Include(x => x.PCBuildOthers).ThenInclude(x => x.Other)
                .ToListAsync();

            List<PCBuild> newPCBuilds = this.UpdateListOfPCBuildsWithTotalPrice(models);

            return newPCBuilds;

        }

        public override async Task<PCBuild> Get(Guid Id)
        {
            PCBuild model = await this._context.PCBuilds
                .Include(e => e.CPUWatercooler)
                .Include(e => e.Fan)
                .Include(e => e.GraphicsCard)
                .Include(e => e.Motherboard)
                .Include(e => e.PCCase)
                .Include(e => e.PowerSupply)
                .Include(e => e.Processor)
                .Include(e => e.RAM)
                .Include(x => x.PCBuildHardDrives).ThenInclude(x => x.HardDrive)
                .Include(x => x.PCBuildOthers).ThenInclude(x => x.Other)
                .FirstOrDefaultAsync(e => e.PCBuildId == Id);

            PCBuild newPCBuild = this.UpdatePCBuildWithTotalPrice(model);
            return newPCBuild;
        }


        /// <summary>
        /// Reads prices of pc build components, and sum them to get total price, then return total price to the model.
        /// </summary>
        /// <param name="model">PCBuild model.</param>
        /// <returns>Returns pc build with updated total price parameter.</returns>
        private PCBuild UpdatePCBuildWithTotalPrice(PCBuild model)
        {
            decimal totalPrice = new List<decimal>
            {
                model.CPUWatercooler?.Price ?? 0,
                model.Fan?.Price ?? 0,
                model.GraphicsCard?.Price ?? 0,
                model.Motherboard?.Price ?? 0,
                model.PCCase?.Price ?? 0,
                model.PowerSupply?.Price ?? 0,
                model.Processor?.Price ?? 0,
                model.RAM?.Price ?? 0,
                model.PCBuildHardDrives.Sum(x => x.HardDrive?.Price ?? 0),
                model.PCBuildOthers.Sum(x => x.Other?.Price ?? 0)
            }.Sum();
            model.TotalPrice = totalPrice;
            return model;
        }

        /// <summary>
        /// Iterate through list of pc builds, reads prices of all pc build components, sum them and return to each pc build.
        /// </summary>
        /// <param name="pcBuilds">List of PCBuild model.</param>
        /// <returns>Returns list of pc build with updated total prices parameter.</returns>
        private List<PCBuild> UpdateListOfPCBuildsWithTotalPrice(List<PCBuild> pcBuilds)
        {
            var newPCBuilds = new List<PCBuild>();
            foreach (PCBuild build in pcBuilds)
            {
                decimal totalPrice = new List<decimal>
                {
                    build.CPUWatercooler?.Price ?? 0,
                    build.Fan?.Price ?? 0,
                    build.GraphicsCard?.Price ?? 0,
                    build.Motherboard?.Price ?? 0,
                    build.PCCase?.Price ?? 0,
                    build.PowerSupply?.Price ?? 0,
                    build.Processor?.Price ?? 0,
                    build.RAM?.Price ?? 0,
                    build.PCBuildHardDrives.Sum(x => x.HardDrive?.Price ?? 0),
                    build.PCBuildOthers.Sum(x => x.Other?.Price ?? 0)
                }.Sum();
                build.TotalPrice = totalPrice;
                newPCBuilds.Add(build);
            }
            return newPCBuilds;
        }


    }
}
