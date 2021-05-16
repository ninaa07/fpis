using FPIS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPIS.DataAccess.Configurations
{
    public class DobavljacConfiguration : BaseEntityConfiguration<Dobavljac>
    {
        public override void Configure(EntityTypeBuilder<Dobavljac> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Naziv).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.Drzava)
                .WithMany(x => x.Dobavljaci)
                .HasForeignKey(x => x.DrzavaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Grad)
                .WithMany(x => x.Dobavljaci)
                .HasForeignKey(x => x.GradId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Ulica)
              .WithMany(x => x.Dobavljaci)
              .HasForeignKey(x => x.UlicaId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
