using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.DBContext
{
    public class PCBuilderContext : DbContext
    {
        public PCBuilderContext(DbContextOptions<PCBuilderContext> options) : base(options)
        {
        }

        public DbSet<PCBuild> PCBuilds { get; set; }
        public DbSet<Processor> Processors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure that specified processorId, in PCBuild class are not unique!
            modelBuilder.Entity<PCBuild>().HasIndex(x => x.ProcessorId).IsUnique(false);


        }

    }
}
