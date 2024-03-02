using Microsoft.EntityFrameworkCore;
using scrap.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace scrap.Connection
{
    internal class MyDbContext:DbContext
    {
        public DbSet<ModeloCpu> ModeloCpus { get; init; }
        public DbSet<ModeloGpu> ModeloGpus { get; init; }
        public DbSet<ModeloPlacas> ModeloPlaca { get; init; }
        public DbSet<ModeloRam> ModeloRams { get; init; }
        public DbSet<ModelosSsd> ModelosSsds { get; init; }
        public DbSet<ModeloPsu> ModeloPsus { get; init; }
        public DbSet<ModeloCooler> ModeloCoolers { get; init; }
        public DbSet<ModeloCase> ModeloCases { get; init; }
        public DbSet<ModeloMonitor> ModeloMonitors { get; init; }

        public MyDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
            {
                warnings.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning);
            });

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ModeloCpu>().ToCollection("ModeloCpu");
            modelBuilder.Entity<ModeloGpu>().ToCollection("ModeloGpu");
            modelBuilder.Entity<ModeloPlacas>().ToCollection("ModeloPlacas");
            modelBuilder.Entity<ModeloRam>().ToCollection("ModeloRam");
            modelBuilder.Entity<ModelosSsd>().ToCollection("ModelosSsd");
            modelBuilder.Entity<ModeloPsu>().ToCollection("ModeloPsu");
            modelBuilder.Entity<ModeloCooler>().ToCollection("ModeloCooler");
            modelBuilder.Entity<ModeloCase>().ToCollection("ModeloCase");
            modelBuilder.Entity<ModeloMonitor>().ToCollection("ModeloMonitor");
        }
    }
}
