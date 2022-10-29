using Microsoft.EntityFrameworkCore;
using RAPC9Y_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPC9Y_HFT_2022231.Repository
{
    public class LoLDbContext : DbContext
    {
        public virtual DbSet<Champions> Champions { get; set; }

        public virtual DbSet<Lanes> Lanes { get; set; }

        public virtual DbSet<Regions> Regions { get; set; }

        public LoLDbContext()
        {
            this.Database.EnsureCreated();
        }

        public LoLDbContext(DbContextOptions<LoLDbContext> options):base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                        .UseLazyLoadingProxies()
                        .UseInMemoryDatabase("LolDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Champions>(champs => champs
            .HasOne(champs => champs.Lane)
            .WithMany(lane => lane.ChampionsByLanes)
            .HasForeignKey(champs => champs.LaneId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Champions>(champs => champs
            .HasOne(champs => champs.Region)
            .WithMany(regions => regions.ChampionsByRegions)
            .HasForeignKey(champs => champs.RegionId)
            .OnDelete(DeleteBehavior.Cascade));
        }

    }
}
