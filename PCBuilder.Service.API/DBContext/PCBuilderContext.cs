using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.API.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PCBuilder.Service.API.DBContext
{
    public class PCBuilderContext : DbContext
    {
        public PCBuilderContext(DbContextOptions<PCBuilderContext> options) : base(options)
        {
        }

        public DbSet<PCBuild> PCBuilds { get; set; }
        public DbSet<Other> Others { get; set; }


        //public DbSet<Processor> Processors { get; set; }
        //public DbSet<Motherboard> Motherboards { get; set; }
        //public DbSet<RAM> RAMs { get; set; }
        //public DbSet<GraphicsCard> GraphicsCards { get; set; }
        //public DbSet<HardDrive> HardDrives { get; set; }
        //public DbSet<CPUWatercooler> CPUWatercooler { get; set; }
        //public DbSet<Fan> Fan { get; set; }
        //public DbSet<PCCase> PCCase { get; set; }
        //public DbSet<PowerSupply> PowerSupply { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            System.Collections.Generic.IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry> entries = this.ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).ModifiedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure that specified processorId, in PCBuild class are not unique!
            //modelBuilder.Entity<PCBuild>().HasIndex(x => x.ProcessorId).IsUnique(false);
            //modelBuilder.Entity<PCBuild>().HasIndex(x => x.MotherboardId).IsUnique(false);
            //modelBuilder.Entity<PCBuild>().HasIndex(x => x.RAMId).IsUnique(false);
            //modelBuilder.Entity<PCBuild>().HasIndex(x => x.GraphicsCardId).IsUnique(false);
            //modelBuilder.Entity<PCBuild>().HasIndex(x => x.HardDrivedId).IsUnique(false);
            //modelBuilder.Entity<PCBuild>().HasIndex(x => x.CPUWatercoolerId).IsUnique(false);
            //modelBuilder.Entity<PCBuild>().HasIndex(x => x.FanId).IsUnique(false);
            //modelBuilder.Entity<PCBuild>().HasIndex(x => x.PCCaseId).IsUnique(false);
            //modelBuilder.Entity<PCBuild>().HasIndex(x => x.PowerSupplyId).IsUnique(false);


            //modelBuilder.Entity<PCBuild>().HasIndex(x => x.OtherId).IsUnique(false);
            //modelBuilder.Entity<PCBuild>().HasMany(p => p.Others).(i => i.PCBuild).Map(t => t.MapLeftKey("CourseID").MapRightKey("InstructorID").ToTable("CourseInstructor"));
            //modelBuilder.Entity<Other>()
            //    .HasMany(c => c.PCBuild).WithMany(i => i.).Map(t => t.MapLeftKey("CourseID").MapRightKey("InstructorID").ToTable("CourseInstructor"));

            modelBuilder.Entity<PCBuildOther>()
                .HasKey(po => new { po.PCBuildId, po.OtherId });

            modelBuilder.Entity<PCBuildOther>().HasOne(po => po.PCBuild).WithMany(p => p.PCBuildOthers).HasForeignKey(po => po.PCBuildId);
            //modelBuilder.Entity<PCBuildOther>().HasOne(po => po.Other).WithMany(p => p.PCBuildOthers).HasForeignKey(po => po.OtherId);


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
