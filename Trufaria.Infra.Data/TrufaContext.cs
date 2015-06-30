using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trufaria.Domain;

namespace Trufaria.Infra.Data
{
    public class TrufaContext : DbContext
    {
        public TrufaContext() : base("TrufasDb") {
        
        }

        public DbSet<Trufa> Trufas { get; set; }
        public DbSet<Sabor> Sabores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trufa>()
                .HasMany(x => x.Sabores)
                .WithOptional().WillCascadeOnDelete(true);
        }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trufa>().ToTable("TBTrufa");
            modelBuilder.Entity<Trufa>()
                .Property(b => b.DataFabricacao)
                .IsRequired();

            modelBuilder.Entity<Sabor>().ToTable("TBSabor");
            modelBuilder.Entity<Sabor>()
                .Property(b => b.NameSabor)
                .IsRequired()
                .HasMaxLength(255);
        }*/

    }
}