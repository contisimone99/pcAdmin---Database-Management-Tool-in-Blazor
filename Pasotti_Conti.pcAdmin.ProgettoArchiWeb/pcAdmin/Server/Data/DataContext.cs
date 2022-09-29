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
            //Diversi Model da Inserire ad esempio in Diversi DB
            modelBuilder.Entity<SuperHero>().HasData(
           new SuperHero { Id = 1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", ComicId = 1 },
           new SuperHero { Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", ComicId = 2 }
          // new SuperHero { Id = 1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", ComicId = 1 },
          // new SuperHero { Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", ComicId = 2 }
          // new SuperHero { Id = 1, FirstName = "Tony", LastName = "Stark", HeroName = "Iron Man", ComicId = 1 },
          // new SuperHero { Id = 2, FirstName = "Steve", LastName = "Rogers", HeroName = "Captain America", ComicId = 1 }
                );


            modelBuilder.Entity<Comic>().HasData(
                 new Comic { Id = 1, Name = "Marvel" },
                 new Comic { Id = 2, Name = "DC" }
                );

            //Per Migrations SQLSERVER
            modelBuilder.Entity<TablesList_SQLSERVER>().HasNoKey();
            modelBuilder.Entity<TablePrimaryKey_SQLSERVER>().HasNoKey();
            modelBuilder.Entity<TableForeignKey_SQLSERVER>().HasNoKey();
            modelBuilder.Entity<TableIndex_SQLSERVER>().HasNoKey();

            //Per Migrations SQLITE
             modelBuilder.Entity<TablesList_SQLITE>().HasNoKey();
             modelBuilder.Entity<TablePrimaryKey_SQLITE>().HasNoKey();
             modelBuilder.Entity<TableForeignKey_SQLITE>().HasNoKey();
             modelBuilder.Entity<TableIndex_SQLITE>().HasNoKey();

            //Per Migrations POSTGRESQL
             modelBuilder.Entity<TablesList_POSTGRESQL>().HasNoKey();
             modelBuilder.Entity<TablePrimaryKey_POSTGRESQL>().HasNoKey();
             modelBuilder.Entity<TableForeignKey_POSTGRESQL>().HasNoKey();
             modelBuilder.Entity<TableIndex_POSTGRESQL>().HasNoKey();



            

        }

        public DbSet<TablesList_SQLSERVER> TablesList_SQLSERVER { get; set; }
        public DbSet<TablePrimaryKey_SQLSERVER> TablePrimaryKey_SQLSERVER { get; set; }
        public DbSet<TableForeignKey_SQLSERVER> TableForeignKey_SQLSERVER { get; set; }
        public DbSet<TableIndex_SQLSERVER> TableIndex_SQLSERVER { get; set; }

        public DbSet<TablesList_SQLITE> TablesList_SQLITE { get; set; }
        public DbSet<TablePrimaryKey_SQLITE> TablePrimaryKey_SQLITE { get; set; }
        public DbSet<TableForeignKey_SQLITE> TableForeignKey_SQLITE { get; set; }
        public DbSet<TableIndex_SQLITE> TableIndex_SQLITE { get; set; }

        public DbSet<TablesList_POSTGRESQL> TablesList_POSTGRESQL { get; set; }
        public DbSet<TablePrimaryKey_POSTGRESQL> TablePrimaryKey_POSTGRESQL { get; set; }
        public DbSet<TableForeignKey_POSTGRESQL> TableForeignKey_POSTGRESQL { get; set; }
        public DbSet<TableIndex_POSTGRESQL> TableIndex_POSTGRESQL { get; set; }

    }
}
