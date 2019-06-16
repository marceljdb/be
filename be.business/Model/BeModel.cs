using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlServerCe;
using System.Text;

namespace be.business.Model
{
    public class BeModel : DbContext
    {
        public const string CONNECTION = "MovimentoConnection";
        public const string SCHEMA_PROPERTY = CONNECTION + ".Schema";

        public BeModel()
            : base(new SqlCeConnection(@"Data Source="+ AppDomain.CurrentDomain.BaseDirectory + "bedb.sdf;Password=dbpass"), true)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<MovimentoEntity> Movimento { get; set; }


        protected void SetupSchema(DbModelBuilder modelBuilder)
        {
            var schemaName = ConfigurationManager.AppSettings[SCHEMA_PROPERTY];

            if (!string.IsNullOrEmpty(schemaName))
                modelBuilder.HasDefaultSchema(schemaName);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetupSchema(modelBuilder);
        }

        }
    }
