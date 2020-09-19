using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.API.Models;
using System;

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

            modelBuilder.Entity<Processor>().HasData(
               new Processor
               {
                   Id = Guid.NewGuid(),
                   Name = "i7",
                   Link = "no url",
                   ProductCollection = "i7 10th gen",
                   NumberOfCores = 4,
                   NumberOfThreads = 4,
                   Cache = 8,
                   TDP = 100,
                   ProcessorBaseFrequency = 1
               }
            );

        }

    }
}
