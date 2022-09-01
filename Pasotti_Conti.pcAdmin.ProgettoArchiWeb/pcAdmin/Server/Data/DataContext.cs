using Microsoft.EntityFrameworkCore;
using pcAdmin.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pcAdmin.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comic>().HasData(
               new Comic { Id = 1, Name = "Marvel" },
               new Comic { Id = 2, Name = "DC" }
           );

            modelBuilder.Entity<SuperHero>().HasData(
                // new SuperHero { Id = 1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", ComicId = 1 },
                // new SuperHero { Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", ComicId = 2 }
                // new SuperHero { Id = 1, FirstName = "Tony", LastName = "Stark", HeroName = "Iron Man", ComicId = 1 },
                // new SuperHero { Id = 2, FirstName = "Steve", LastName = "Rogers", HeroName = "Captain America", ComicId = 1 }
                 new SuperHero { Id = 1, FirstName = "Dick", LastName = "Grayson", HeroName = "NightWing", ComicId = 2 },
                 new SuperHero { Id = 2, FirstName = "Jason", LastName = "Todd", HeroName = "Red Robin", ComicId = 2 }

            );
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<TablesList> TablesList { get; set; }
        public DbSet<TableInfo> TableInfo { get; set; }
        public DbSet<TablePrimaryKey> TablePrimaryKey { get; set; }
        public DbSet<TableForeignKey> TableForeignKey { get; set; }
        public DbSet<TableIndex> TableIndex { get; set; }
    }
}
