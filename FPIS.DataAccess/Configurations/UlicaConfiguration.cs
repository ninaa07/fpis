using FPIS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FPIS.DataAccess.Configurations
{
    public class UlicaConfiguration : BaseEntityConfiguration<Ulica>
    {
        public override void Configure(EntityTypeBuilder<Ulica> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Grad)
                .WithMany(x => x.Ulice)
                .HasForeignKey(x => x.GradId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
