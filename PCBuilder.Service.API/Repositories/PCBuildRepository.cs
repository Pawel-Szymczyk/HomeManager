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
            _context = context;
        }
        // We can add new methods specific to the movie repository here in the future

        public override async Task<PCBuild> Update(PCBuild model)
        {
            // the problem here is why normal update is not working?
            try
            {
                // get list of all items with model id from db
                var buildsList = await this._context.PCBuilds.Where(b => b.PCBuildId == model.PCBuildId).ToListAsync();
                // remove these objs from db
                if (buildsList.Count > 0)
                {
                    this._context.RemoveRange(buildsList);
                    await _context.SaveChangesAsync();
                }

                // add pcbuild id to each of referencing objects in the model
                model.PCBuildGraphicsCards?.ForEach(x => x.PCBuildId = model.PCBuildId);
                model.PCBuildHardDrives?.ForEach(x => x.PCBuildId = model.PCBuildId);
                model.PCBuildOthers?.ForEach(x => x.PCBuildId = model.PCBuildId);
                

                // add model to db and save changes
                await this._context.AddAsync(model);
                await this._context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }



           

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

                

            return await _context.PCBuilds
                .Include(x => x.CPUWatercooler)
                .Include(e => e.Fan)
                .Include(e => e.Motherboard)
                .Include(e => e.PCCase)
                .Include(e => e.PowerSupply)
                .Include(e => e.Processor)
                .Include(e => e.RAM)
                .Include(x => x.PCBuildGraphicsCards).ThenInclude(x => x.GraphicsCard)
                .Include(x => x.PCBuildHardDrives).ThenInclude(x => x.HardDrive)
                .Include(x => x.PCBuildOthers).ThenInclude(x => x.Other)
                .ToListAsync();

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
            //.Include(e => e.PCCase)
            //.Include(e => e.PowerSupply)
            //.Include(e => e.Processor)
            //.Include(e => e.RAM)
            //    .FirstOrDefaultAsync(e => e.Id == Id);
            getTotalPrice();

            return await _context.PCBuilds
                .Include(x => x.CPUWatercooler)
                .Include(e => e.Fan)
                .Include(e => e.Motherboard)
                .Include(e => e.PCCase)
                .Include(e => e.PowerSupply)
                .Include(e => e.Processor)
                .Include(e => e.RAM)
                .Include(x => x.PCBuildGraphicsCards).ThenInclude(x => x.GraphicsCard)
                .Include(x => x.PCBuildHardDrives).ThenInclude(x => x.HardDrive)
                .Include(x => x.PCBuildOthers).ThenInclude(x => x.Other)
                .FirstOrDefaultAsync(e => e.PCBuildId == Id);


        }

        private void getTotalPrice()
        {
            // dokkonczyc to 
            // zebrac wszystkie obiekty w listach 
            // dostac ich ceny 
            //i sumowac je
            // na koniec dodac do modelu
            var y = this._context.PCBuilds.Select(x => x.CPUWatercooler).ToList();

            var totalPrice = new List<decimal>
            {
            };

            //{
            //    get
            //{
            //        var totalPrice = new List<decimal>
            //    {
            //        this.CPUWatercooler?.Price ?? 0,
            //        this.Fan?.Price ?? 0,
            //        //this.GraphicsCard?.Price ?? 0,
            //        //this.HardDrive?.Price ?? 0,
            //        this.Motherboard?.Price ?? 0,
            //        //this.Other?.Price ?? 0,
            //        this.PCCase?.Price ?? 0,
            //        this.PowerSupply?.Price ?? 0,
            //        this.Processor?.Price ?? 0,
            //        this.RAM?.Price ?? 0

            //    };

            //        var kl = this.PCBuildGraphicsCards.FindAll(x => x.PCBuildId == PCBuildId);

            //        foreach (var k in kl)
            //        {
            //            var g = k.
            //        }


            //        return totalPrice.Sum();
            //    }

            //    //set; 

            //}
        }
        
    }
}
