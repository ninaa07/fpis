using FPIS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPIS.DataAccess.Configurations
{
    public class StavkaUlazneFaktureConfiguration
    {
        public virtual void Configure(EntityTypeBuilder<StavkaUlazneFakture> builder)
        {
            builder.HasKey(x => new { x.Id, x.UlaznaFakturaId});

            builder.HasOne(x => x.UlaznaFaktura)
                 .WithMany(x => x.StavkeUlazneFakture)
                 .HasForeignKey(x => x.UlaznaFakturaId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Proizvod)
                 .WithMany(x => x.StavkeUlazneFakture)
                 .HasForeignKey(x => x.UlaznaFakturaId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
