using FPIS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FPIS.DataAccess.Configurations
{
    public class PackingListaConfiguration : BaseEntityConfiguration<PackingLista>
    {
        public override void Configure(EntityTypeBuilder<PackingLista> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Dobavljac)
                .WithMany(x => x.PackingListe)
                .HasForeignKey(x => x.DobavljacId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
