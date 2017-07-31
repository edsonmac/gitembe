using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace gitembe.Models
{
    public class gitembeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public gitembeContext() : base("name=gitembeContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<tCargo>().ToTable("tCargos");
            modelBuilder.Entity<tEscalafon>().ToTable("tEscalafones");
            modelBuilder.Entity<tFuncionario>().ToTable("tFuncionarios");
            modelBuilder.Entity<tLugar>().ToTable("tLugares");
            modelBuilder.Entity<tMunicipio>().ToTable("tMunicipios");
            modelBuilder.Entity<tPersona>().ToTable("tPersonas");
            modelBuilder.Entity<tTiempo>().ToTable("tTiempos");
        }

        public System.Data.Entity.DbSet<gitembe.Models.tPersona> Personas { get; set; }

        public System.Data.Entity.DbSet<gitembe.Models.tCargo> tCargos { get; set; }

        public System.Data.Entity.DbSet<gitembe.Models.tMunicipio> tMunicipios { get; set; }

        public System.Data.Entity.DbSet<gitembe.Models.tTiempo> tTiempoes { get; set; }

        public System.Data.Entity.DbSet<gitembe.Models.tEscalafon> tEscalafons { get; set; }

        public System.Data.Entity.DbSet<gitembe.Models.tFuncionario> tFuncionarios { get; set; }

        public System.Data.Entity.DbSet<gitembe.Models.tLugar> tLugars { get; set; }
    }
}
