using FPIS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace FPIS.DataAccess
{
    public class ApplicationContext: DbContext
    {
        public virtual DbSet<Dobavljac> Dobavljac { get; set; }
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<PackingLista> PackingLista { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }
        public virtual DbSet<Rang> Rang { get; set; }
        public virtual DbSet<StavkaUlazneFakture> StavkaUlazneFakture { get; set; }
        public virtual DbSet<UlaznaFaktura> UlaznaFaktura { get; set; }
        public virtual DbSet<Ulica> Ulica { get; set; }

        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                builder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }
        }
    }
}
