using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using MVC_DDD.Domain.Entities;
using MVC_DDD.Infra.Data.EntityConfig;

namespace MVC_DDD.Infra.Data.Contexto
{
    public class MVC_DDDContext : DbContext
    {
        public MVC_DDDContext()
         : base("MVC_DDD")
        {
            
        }

        //public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<Produto> Produtos { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Country> Countries { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

			modelBuilder.Configurations.Add(new CountryConfiguration());
			modelBuilder.Configurations.Add(new CompanyConfiguration());
		}

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegistrationDate") != null))// || entry.Entity.GetType().GetProperty("RegistrationDate") != null))
            {

                if (entry.State == EntityState.Added)
                {
                      entry.Property("RegistrationDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                      entry.Property("RegistrationDate").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
