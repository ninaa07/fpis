using FPIS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPIS.DataAccess.Configurations
{
    public class UlaznaFakturaConfiguration : BaseEntityConfiguration<UlaznaFaktura>
    {
        public override void Configure(EntityTypeBuilder<UlaznaFaktura> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Iznos).IsRequired();
            builder.Property(x => x.PackingListaId).IsRequired();

            builder.HasOne(x => x.PackingLista)
                .WithMany(x => x.UlazneFakture)
                .HasForeignKey(x => x.PackingListaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
