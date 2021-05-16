using FPIS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPIS.DataAccess.Configurations
{
    public class GradConfiguration : BaseEntityConfiguration<Grad>
    {
        public override void Configure(EntityTypeBuilder<Grad> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Drzava)
                .WithMany(x => x.Gradovi)
                .HasForeignKey(x => x.DrzavaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
